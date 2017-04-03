using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
    /// <summary>
    /// 故障类
    /// </summary>
    public class Error
    {
        /// <summary>
        /// 故障源
        /// </summary>
        public class ErrorFrom
        {
            public string Value
            { get; set; }
            public ErrorFrom()
            {
                Value = "";
            }
        }
        /// <summary>
        /// 故障名称
        /// </summary>
        public class Errors
        {
            public string Value
            { get; set; }
            public List<ErrorFrom> ErrorFrom
            { get; set; }
            public Errors()
            {
                Value = "";
                ErrorFrom = new List<ErrorFrom>();
            }
        }
        /// <summary>
        /// 故障分类
        /// </summary>
        public class ErrorEnum
        {
            public string Value
            { get; set; }
            public List<Errors> Errors
            { get; set; }
            public ErrorEnum()
            {
                Value = "";
                Errors = new List<Errors>();
            }
        }
        /// <summary>
        /// 每个工位拥有的故障
        /// </summary>
        public class ErrorStation
        {
            public int WorkStation
            { get; set; }
            public List<ErrorEnum> ErrorEnum
            { get; set; }
            public ErrorStation()
            {
                WorkStation = 0;
                ErrorEnum = new List<ErrorEnum>();
            }
        }
        /// <summary>
        /// 清除故障工位设置
        /// </summary>
        /// <param name="conn"></param>
        public static void ClearStation(All.Class.DataReadAndWrite conn)
        {
            conn.Write("delete from SetErrorStation");
        }
        /// <summary>
        /// 清除故障列表
        /// </summary>
        /// <param name="conn"></param>
        public static void ClearEnum(All.Class.DataReadAndWrite conn)
        {
            conn.Write("delete from SetError");
            conn.Write("delete from SetErrorFather");
            conn.Write("delete from SetErrorSon");
        }
        /// <summary>
        /// 保存故障列表
        /// </summary>
        /// <param name="allErrorEnum"></param>
        /// <param name="conn"></param>
        public static bool  Save(List<ErrorEnum> allErrorEnum, All.Class.DataReadAndWrite conn)
        {
            bool result = false;
            int count = 0;
            ClearEnum(conn);
            if (allErrorEnum != null)
            {
                allErrorEnum.ForEach(
                    errorEnum =>
                    {
                        if (conn.Write(string.Format("insert into SetErrorFather (Error) values ('{0}')", errorEnum.Value)) >= 1)
                        {
                            count++;
                        }
                        if (errorEnum.Errors != null)
                        {
                            errorEnum.Errors.ForEach(//故障名称
                                error =>
                                {
                                    if (conn.Write(string.Format("insert into SetError (Error,FatherID) values ('{0}','{1}')",
                                        error.Value, errorEnum.Value)) >= 1)
                                    {
                                        count++;
                                    }

                                    if (error.ErrorFrom != null)
                                    {
                                        error.ErrorFrom.ForEach(//故障来源
                                            errorFrom =>
                                            {
                                                if (conn.Write(string.Format("insert into SetErrorSon (Error,FatherID) values ('{0}','{1}')",
                                                     errorFrom.Value, error.Value)) >= 1)
                                                {
                                                    count++;
                                                }
                                            });
                                    }
                                });
                        }
                    });
            }
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 保存故障
        /// </summary>
        /// <param name="allErrorStation"></param>
        /// <param name="conn"></param>
        public static bool Save(List<ErrorStation> allErrorStation, All.Class.DataReadAndWrite conn)
        {
            bool result = false;
            int count = 0;
            ClearStation(conn);
            if (allErrorStation != null)
            {
                allErrorStation.ForEach(//工位
                    errorStation =>
                    {
                        if (errorStation.ErrorEnum != null)
                        {
                            errorStation.ErrorEnum.ForEach(//分类
                                errorEnum => {
                                    if (conn.Write(string.Format("insert into SetErrorStation (Station,ErrorFather) values ({0},'{1}')",
                                        errorStation.WorkStation, errorEnum.Value)) >= 1)
                                    {
                                        count++;
                                    }
                                });
                        }
                    });
            }
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 获取所有工位故障信息
        /// </summary>
        /// <returns></returns>
        public static List<ErrorStation> GetError(All.Class.DataReadAndWrite conn)
        {
            return GetError(0, conn);
        }
        /// <summary>
        /// 获取所有故障设置
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<ErrorEnum> GetAllErrorSet(All.Class.DataReadAndWrite conn)
        {
            List<ErrorEnum> result = new List<ErrorEnum>();
            string errorEnum = "";
            string errorValue = "";
            string errorFrom = "";
            int errorEnumIndex = 0;
            int errorsIndex = 0;
            int errorFromIndex = 0;
            ErrorEnum tmpErrorEnum;
            Errors tmpErrors;
            ErrorFrom tmpErrorFrom;
            using (DataTable dt = conn.Read("select ErrorEnum,ErrorValue,ErrorFrom from V_AllError"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        errorEnum = All.Class.Num.ToString(dt.Rows[i]["ErrorEnum"], "");
                        errorValue = All.Class.Num.ToString(dt.Rows[i]["ErrorValue"], "");
                        errorFrom = All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"], "");

                        //查找是否有当前故障分类 
                        errorEnumIndex = result.FindIndex(
                            tmp =>
                            {
                                return tmp.Value == errorEnum;
                            });
                        if (errorEnumIndex < 0)//添加一个故障分类 
                        {
                            tmpErrorEnum = new ErrorEnum();
                            tmpErrorEnum.Value = errorEnum;
                            result.Add(tmpErrorEnum);
                            errorEnumIndex = result.Count - 1;
                        }
                        //查找是否有当前故障
                        errorsIndex = result[errorEnumIndex].Errors.FindIndex(
                            tmp =>
                            {
                                return tmp.Value == errorValue;
                            });
                        if (errorsIndex < 0)//添加一个故障分类
                        {
                            tmpErrors = new Errors();
                            tmpErrors.Value = errorValue;
                            result[errorEnumIndex].Errors.Add(tmpErrors);
                            errorsIndex = result[errorEnumIndex].Errors.Count - 1;
                        }
                        //查找是否有当前故障源
                        errorFromIndex = result[errorEnumIndex].Errors[errorsIndex].ErrorFrom.FindIndex(
                            tmp =>
                            {
                                return tmp.Value == errorFrom;
                            });
                        if (errorFromIndex < 0)//添加一个故障源
                        {
                            tmpErrorFrom = new ErrorFrom();
                            tmpErrorFrom.Value = errorFrom;
                            result[errorEnumIndex].Errors[errorsIndex].ErrorFrom.Add(tmpErrorFrom);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取指定工位故障
        /// </summary>
        /// <param name="workStation"></param>
        /// <returns></returns>
        public static List<ErrorStation> GetError(int workStation, All.Class.DataReadAndWrite conn)
        {
            List<ErrorStation> error = new List<ErrorStation>();
            ErrorStation tmpStation;
            ErrorEnum tmpErrorEnum;

            int station = 0;
            string errorEnum = "";

            int stationIndex = 0;
            int errorEnumIndex = 0;
            string sql = "select Station,Error from V_ErrorStation";
            if (workStation > 0)
            {
                sql = string.Format("{0} where Station={1}", sql, workStation);
            }
            sql = string.Format("{0} order by Station,Error", sql);
            using (DataTable dt = conn.Read(sql))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        station = All.Class.Num.ToInt(dt.Rows[i]["Station"]);
                        errorEnum = All.Class.Num.ToString(dt.Rows[i]["Error"], "");
                        //查找是否已添加当前工位
                        stationIndex = error.FindIndex(
                           tmp =>
                           {
                               return tmp.WorkStation == station;
                           });
                        if (stationIndex < 0)//添加一个工位数据
                        {
                            tmpStation = new ErrorStation();
                            tmpStation.WorkStation = station;
                            error.Add(tmpStation);
                            stationIndex = error.Count - 1;
                        }
                        //查找是否有当前故障分类 
                        errorEnumIndex = error[stationIndex].ErrorEnum.FindIndex(
                            tmp =>
                            {
                                return tmp.Value == errorEnum;
                            });
                        if (errorEnumIndex < 0)//添加一个故障分类 
                        {
                            tmpErrorEnum = new ErrorEnum();
                            tmpErrorEnum.Value = errorEnum;
                            error[stationIndex].ErrorEnum.Add(tmpErrorEnum);
                            errorEnumIndex = error[stationIndex].ErrorEnum.Count - 1;
                        }
                    }
                }
            }
            return error;
        }
    }
    /// <summary>
    /// 测试过程故障
    /// </summary>
    public class TestError
    {
        /// <summary>
        /// 工位号
        /// </summary>
        public int WorkStation
        { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode
        { get; set; }
        /// <summary>
        /// 故障名称
        /// </summary>
        public string Error
        { get; set; }
        /// <summary>
        /// 故障代码
        /// </summary>
        public int ErrorNum
        { get; set; }
        /// <summary>
        /// 故障录入时间
        /// </summary>
        public DateTime ErrorTime
        { get; set; }
        /// <summary>
        /// 是否返修
        /// </summary>
        public bool Repair
        { get; set; }
        /// <summary>
        /// 返修时间
        /// </summary>
        public DateTime RepairTime
        { get; set; }
        /// <summary>
        /// 故障源
        /// </summary>
        public string ErrorFrom
        { get; set; }
        /// <summary>
        /// 故障位置
        /// </summary>
        public int ErrorSpace
        { get; set; }
        public TestError()
        {
            this.Barcode = "";
            this.WorkStation = 0;
            this.Error = "";
            this.ErrorNum = 0;
            this.ErrorTime = DateTime.Now;
            this.Repair = false;
            this.RepairTime = DateTime.Now;
            this.ErrorFrom = "";
            this.ErrorSpace = 0;
        }
        /// <summary>
        /// 刷新已导出的故障
        /// </summary>
        public static void DelTestError(All.Class.DataReadAndWrite conn)
        {
            conn.Write("delete from StatueError Where Repair='true'");
        }
        /// <summary>
        /// 获取指定工位未返修的故障
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static List<TestError> GetTestError(string barcode, All.Class.DataReadAndWrite conn)
        {
            List<TestError> result = new List<TestError>();
            TestError testError;
            using (DataTable dt = conn.Read(string.Format("select * from StatueError where Barcode={0} and Repair='false'", barcode)))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    testError = new TestError();
                    testError.Barcode = All.Class.Num.ToString(dt.Rows[i]["Barcode"]);
                    testError.Error = All.Class.Num.ToString(dt.Rows[i]["Error"]);
                    testError.ErrorNum = All.Class.Num.ToInt(dt.Rows[i]["ErrorNum"]);
                    testError.ErrorTime = All.Class.Num.ToDateTime(dt.Rows[i]["ErrorTime"]);
                    testError.Repair = All.Class.Num.ToBool(dt.Rows[i]["Repair"]);
                    testError.RepairTime = All.Class.Num.ToDateTime(dt.Rows[i]["RepairTime"]);
                    testError.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                    testError.ErrorFrom = All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"]);
                    testError.ErrorSpace = All.Class.Num.ToInt(dt.Rows[i]["ErrorSpace"]);
                    result.Add(testError);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取已返修完成的故障
        /// </summary>
        /// <returns></returns>
        public static List<TestError> GetTestOverError(All.Class.DataReadAndWrite conn)
        {
            List<TestError> result = new List<TestError>();
            TestError testError;
            using (DataTable dt = conn.Read(string.Format("select * from StatueError where Repair='true'")))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    testError = new TestError();
                    testError.Barcode = All.Class.Num.ToString(dt.Rows[i]["Barcode"]);
                    testError.Error = All.Class.Num.ToString(dt.Rows[i]["Error"]);
                    testError.ErrorNum = All.Class.Num.ToInt(dt.Rows[i]["ErrorNum"]);
                    testError.ErrorTime = All.Class.Num.ToDateTime(dt.Rows[i]["ErrorTime"]);
                    testError.Repair = All.Class.Num.ToBool(dt.Rows[i]["Repair"]);
                    testError.RepairTime = All.Class.Num.ToDateTime(dt.Rows[i]["RepairTime"]);
                    testError.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                    testError.ErrorFrom = All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"]);
                    testError.ErrorSpace = All.Class.Num.ToInt(dt.Rows[i]["ErrorSpace"]);
                    result.Add(testError);
                }
            }
            return result;
        }
    }
}
