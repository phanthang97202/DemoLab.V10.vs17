using System;
using System.Data;
//using System.Xml.Linq;
using System.Threading;
using System.Windows.Forms;

//using System.Threading.Tasks;
using CmUtils = CommonUtils;
//using TDAL = EzDAL.MyDB;
//using TDALUtils = EzDAL.Utils;
//using TConst = IDM.Constants;
//using TUtils = IDM.Utils;
//using TError = IDM.Errors;


namespace ZTest01
{
    public partial class ZTest : Form
    {
        #region // Constructors and Destructors:
        public ZTest()
        {
            InitializeComponent();
        }

        #endregion

        #region // TestMix:
        private void btnTestMix_Click(object sender, EventArgs e)
        {
            try
            {
                TestMix_01_CallService();

            }
            catch (Exception exc)
            {
                CommonForms.Utils.ProcessExc(exc);
            }
        }

        private void TestMix_01_CallService()
        {
            ////
            WSDVNAUD.WS ws = new WSDVNAUD.WS();
            string strUrl = ws.Url;
            //string strUrl = "http://118.70.129.122:12608/idocNet.Test.Demo.Lab.Sv.V10/WS.asmx";
            CmUtils.WebServiceUtils.Refine(ws, strUrl, 123456000, true);
            ////
            //object objResult = ws.Cm_Test();
            ////
            string strGwUserCode = "idocNet.Demo.Lab.STD.Sv";
            string strGwPassword = "idocNet.Demo.Lab.STD.Sv";
            //string strTid = DateTime.Now.ToString("yyyyMMdd.HHmmss.ffffff");
            string strRootSvCode = "WEBAPP";
            string strRootUserCode = "SYSADMIN";
            string strServiceCode = "WEBAPP";
            string strUserCode = "SYSADMIN";
            string strLanguageCode = "EN-US";
            string strUserPassword = "1";
            string strOtherInfo = "strOtherInfo = 123456";
            bool bTest = false;
            string strFt_RecordStart = "0";
            string strFt_RecordCount = "12345600";
            DataSet mdsResult = null;
            DataTable dtTable0 = null;
            DataTable dtTable1 = null;
            DataTable dtTable2 = null;
            int nSeq = 0;

            #region // Login:
            mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Sys_User_Login(
                strGwUserCode // strGwUserCode
                , strGwPassword // strGwPassword
                , string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++) // strTid
                , strRootSvCode // strRootSvCode
                , strRootUserCode // strRootUserCode
                , strServiceCode // strServiceCode
                , strUserCode // strUserCode
                , strLanguageCode // strLanguageCode
                , strUserPassword // strUserPassword
                , strOtherInfo // strOtherInfo
                ));
            if (CmUtils.CMyDataSet.HasError(mdsResult))
            {
                CommonForms.Utils.ProcessMyDS(mdsResult);
                return;
            }
            string strResult_Remark = Convert.ToString(CmUtils.CMyDataSet.GetRemark(mdsResult));
            string[] arrstrResult = strResult_Remark.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            string strSessionId = arrstrResult[0];
            string strBizName = arrstrResult[1];

            // Pause:
            System.Threading.Thread.Sleep(10);
            #endregion

            #region // Seq_Common_Get:
            if (bTest)
            {
                string strSequenceType = "CAMPAIGNCRAWARDCODE";
                string strParam_Prefix = "Hello";
                string strParam_Postfix = "Bye";
                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Seq_Common_Get(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++) // strTid
                    , strSessionId // strSessionId
                    , strSequenceType
                    , strParam_Prefix
                    , strParam_Postfix
                    ));
                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }

                // Pause:
                System.Threading.Thread.Sleep(10);
            }
            #endregion

            #region // Mst_Common_Get:
            if (bTest)
            {
                string strTableName = "Ins_ClaimDocType";
                object objFilter0 = null;
                object objFilter1 = null;
                object objFilter2 = null;
                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_Common_Get(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++) // strTid
                    , strSessionId // strSessionId
                    , strTableName // strTableName
                    , objFilter0 // objFilter0
                    , objFilter1 // objFilter1
                    , objFilter2 // objFilter2
                    ));

                //mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_Province_CheckDB(
                //    strGwUserCode // strGwUserCode
                //    , strGwPassword // strGwPassword
                //    , string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++) // strTid
                //    , strSessionId // strSessionId
                //    , strTableName // strTableName
                //    , objFilter0 // objFilter0
                //    , objFilter1 // objFilter1
                //    , objFilter2 // objFilter2
                //    ));
                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }

                // Pause:
                System.Threading.Thread.Sleep(10);
            }
            #endregion

            #region // Mst_POSMType_Create:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_POSMType = new DataTable("Mst_POSMType");

                dt_Mst_POSMType.Columns.Add("POSMType", typeof(object));
                dt_Mst_POSMType.Columns.Add("POSMTypeName", typeof(object));

                dt_Mst_POSMType.Rows.Add(
                    "PMH",
                    "Mô hình sản phẩm"
                    );

                dt_Mst_POSMType.Rows.Add(
                    "PTB",
                    "Trưng bày sp thật"
                    );

                dt_Mst_POSMType.Rows.Add(
                    "PTBMH",
                    "Trưng bày mô hình"
                    );

                dt_Mst_POSMType.Rows.Add(
                    "PTD",
                    "Treo dán"
                    );

                // 
                foreach (DataRow row in dt_Mst_POSMType.Rows)
                {
                    object objPOSMType = row["POSMType"];
                    object objPOSMTypeName = row["POSMTypeName"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_POSMType_Create(
                        strGwUserCode       // strGwUserCode
                        , strGwPassword     // strGwPassword
                        , strTid            // strTid
                        , strSessionId      // strSessionId
                                            ////
                        , objPOSMType       // objPOSMType
                        , objPOSMTypeName   // objPOSMTypeName
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_POSMUnitType_Create:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_POSMUnitType = new DataTable("Mst_POSMUnitType");

                dt_Mst_POSMUnitType.Columns.Add("POSMUnitType", typeof(object));
                dt_Mst_POSMUnitType.Columns.Add("POSMUnitTypeName", typeof(object));

                dt_Mst_POSMUnitType.Rows.Add(
                    "SHEET",
                    "Tờ"
                    );

                dt_Mst_POSMUnitType.Rows.Add(
                    "Unit",
                    "Cái"
                    );

                // 
                foreach (DataRow row in dt_Mst_POSMUnitType.Rows)
                {
                    object objPOSMUnitType = row["POSMUnitType"];
                    object objPOSMUnitTypeName = row["POSMUnitTypeName"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_POSMUnitType_Create(
                        strGwUserCode           // strGwUserCode
                        , strGwPassword         // strGwPassword
                        , strTid                // strTid
                        , strSessionId          // strSessionId
                                                ////
                        , objPOSMUnitType       // objPOSMUnitType
                        , objPOSMUnitTypeName   // objPOSMUnitTypeName
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_POSM_Create:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_POSM = new DataTable("Mst_POSM");

                dt_Mst_POSM.Columns.Add("POSMCode", typeof(object));
                dt_Mst_POSM.Columns.Add("POSMType", typeof(object));
                dt_Mst_POSM.Columns.Add("POSMUnitType", typeof(object));
                dt_Mst_POSM.Columns.Add("POSMName", typeof(object));
                dt_Mst_POSM.Columns.Add("POSMDesc", typeof(object));
                dt_Mst_POSM.Columns.Add("POSMImageFilePath", typeof(object));

                dt_Mst_POSM.Rows.Add(
                    "GB",
                    "PTB",
                    "UNIT",
                    "Giá trưng bày SP",
                    "Kích thước lớn",
                    "Đường dẫn hình ảnh"
                    );

                dt_Mst_POSM.Rows.Add(
                    "GH",
                    "PTB",
                    "UNIT",
                    "Túi treo loại lớn",
                    "Kích thước lớn",
                    "Đường dẫn hình ảnh"
                    );

                dt_Mst_POSM.Rows.Add(
                    "HT",
                    "PTD",
                    "UNIT",
                    "Hộp treo",
                    "Kích thước lớn",
                    "Đường dẫn hình ảnh"
                    );

                dt_Mst_POSM.Rows.Add(
                    "KB",
                    "PTB",
                    "UNIT",
                    "Kệ trưng bày",
                    "Kích thước lớn",
                    "Đường dẫn hình ảnh"
                    );

                dt_Mst_POSM.Rows.Add(
                    "TT",
                    "PTD",
                    "UNIT",
                    "Túi treo",
                    "Kích thước lớn",
                    "Đường dẫn hình ảnh"
                    );



                foreach (DataRow row in dt_Mst_POSM.Rows)
                {
                    object objPOSMCode = row["POSMCode"];
                    object objPOSMType = row["POSMType"];
                    object objPOSMUnitType = row["POSMUnitType"];
                    object objPOSMName = row["POSMName"];
                    object objPOSMDesc = row["POSMDesc"];
                    object objPOSMImageFilePath = row["POSMImageFilePath"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_POSM_Create(
                        strGwUserCode           // strGwUserCode
                        , strGwPassword         // strGwPassword
                        , strTid                // strTid
                        , strSessionId          // strSessionId
                                                ////
                        , objPOSMCode           // objPOSMCode
                        , objPOSMType           // objPOSMType
                        , objPOSMUnitType       // objPOSMUnitType
                        , objPOSMName           // objPOSMName
                        , objPOSMDesc           // objPOSMDesc
                        , objPOSMImageFilePath  // objPOSMImageFilePath
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_StarShopGroup_Create:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_StarShopGroup = new DataTable("Mst_StarShopGroup");

                dt_Mst_StarShopGroup.Columns.Add("SSGrpCode", typeof(object));
                dt_Mst_StarShopGroup.Columns.Add("SSGrpName", typeof(object));

                dt_Mst_StarShopGroup.Rows.Add(
                    "1",
                    "SSGD"
                    );

                dt_Mst_StarShopGroup.Rows.Add(
                    "2",
                    "SSGB"
                    );

                dt_Mst_StarShopGroup.Rows.Add(
                    "3",
                    "SSGA"
                    );

                dt_Mst_StarShopGroup.Rows.Add(
                    "4",
                    "SSGC"
                    );

                dt_Mst_StarShopGroup.Rows.Add(
                    "NORMALOUTLET",
                    "Normaloutlet"
                    );

                dt_Mst_StarShopGroup.Rows.Add(
                    "VIRTUALOUTLET",
                    "Virtualoutlet"
                    );

                // 
                foreach (DataRow row in dt_Mst_StarShopGroup.Rows)
                {
                    object objSSGrpCode = row["SSGrpCode"];
                    object objSSGrpName = row["SSGrpName"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_StarShopGroup_Create(
                        strGwUserCode       // strGwUserCode
                        , strGwPassword     // strGwPassword
                        , strTid            // strTid
                        , strSessionId      // strSessionId
                                            ////
                        , objSSGrpCode      // objSSGrpCode
                        , objSSGrpName      // objSSGrpName
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_StarShopBrand_Create:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_StarShopBrand = new DataTable("Mst_StarShopBrand");

                dt_Mst_StarShopBrand.Columns.Add("SSBrandCode", typeof(object));
                dt_Mst_StarShopBrand.Columns.Add("SSBrandName", typeof(object));

                dt_Mst_StarShopBrand.Rows.Add(
                    "1",
                    "SSD"
                    );

                dt_Mst_StarShopBrand.Rows.Add(
                    "2",
                    "SSB"
                    );

                dt_Mst_StarShopBrand.Rows.Add(
                    "3",
                    "SSA"
                    );

                dt_Mst_StarShopBrand.Rows.Add(
                    "4",
                    "SSC"
                    );

                dt_Mst_StarShopBrand.Rows.Add(
                    "NORMALOUTLET",
                    "Normaloutlet"
                    );

                dt_Mst_StarShopBrand.Rows.Add(
                    "VIRTUALOUTLET",
                    "Virtualoutlet"
                    );

                // 
                foreach (DataRow row in dt_Mst_StarShopBrand.Rows)
                {
                    object objSSBrandCode = row["SSBrandCode"];
                    object objSSBrandName = row["SSBrandName"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_StarShopBrand_Create(
                        strGwUserCode       // strGwUserCode
                        , strGwPassword     // strGwPassword
                        , strTid            // strTid
                        , strSessionId      // strSessionId
                                            ////
                        , objSSBrandCode      // objSSBrandCode
                        , objSSBrandName      // objSSBrandName
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_StarShopType:
            if (bTest)
            {
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);

                DataTable dt_Mst_StarShopType = new DataTable("Mst_StarShopType");

                dt_Mst_StarShopType.Columns.Add("SSGrpCode", typeof(object));
                dt_Mst_StarShopType.Columns.Add("SSBrandCode", typeof(object));
                dt_Mst_StarShopType.Columns.Add("SSTypeName", typeof(object));
                dt_Mst_StarShopType.Columns.Add("SSRate", typeof(object));

                dt_Mst_StarShopType.Rows.Add(
                    "1",
                    "1",
                    "SSType Name 1",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "2",
                    "2",
                    "SSType Name 2",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "3",
                    "3",
                    "SSType Name 3",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "4",
                    "1",
                    "SSType Name 3",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "4",
                    "2",
                    "SSType Name 4",
                    "3"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "4",
                    "4",
                    "SSType Name 4",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "4",
                    "4",
                    "SSType Name 4",
                    "2"
                    );

                dt_Mst_StarShopType.Rows.Add(
                    "NORMALOUTLET",
                    "NORMALOUTLET",
                    "Normaloutlet",
                    "2"
                    );



                foreach (DataRow row in dt_Mst_StarShopType.Rows)
                {
                    object objSSGrpCode = row["SSGrpCode"];
                    object objSSBrandCode = row["SSBrandCode"];
                    object objSSTypeName = row["SSTypeName"];
                    object objSSRate = row["SSRate"];

                    mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_StarShopType_Create(
                        strGwUserCode           // strGwUserCode
                        , strGwPassword         // strGwPassword
                        , strTid                // strTid
                        , strSessionId          // strSessionId
                                                ////
                        , objSSGrpCode          // objSSGrpCode
                        , objSSBrandCode        // objSSBrandCode
                        , objSSTypeName         // objSSTypeName
                        , objSSRate             // objSSRate 
                        ));

                    if (CmUtils.CMyDataSet.HasError(mdsResult))
                    {
                        CommonForms.Utils.ProcessMyDS(mdsResult);
                    }

                    // Pause:
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion

            #region // Mst_CampainCriteria:
            if (bTest)
            {

                ////
                object objFlagIsDelete = "0";
                object objCampaignCrCode = "DZUNGND.IF_ACSINNO.02";
                object objCampaignCrName = "PHANTHANG1";
                object objCampainCriteriaType = "PURCONTRACTNO.57F.00048";

                DataSet dsData = new DataSet();

                ////
                DataTable dtData_Mst_CampainCriteriaScope = new DataTable("Mst_CampainCriteriaScope");
                dtData_Mst_CampainCriteriaScope.Columns.Add("SSGrpCode", typeof(object));
                dtData_Mst_CampainCriteriaScope.Columns.Add("SSBrandCode", typeof(object));
                dtData_Mst_CampainCriteriaScope.Columns.Add("CampainCritScopeDesc", typeof(object));
                dtData_Mst_CampainCriteriaScope.Columns.Add("LevelCode", typeof(object));

                ////
                dtData_Mst_CampainCriteriaScope.Rows.Add("1", "1", "PhanThangTest2", "1");

                ////
                dsData.Tables.Add(dtData_Mst_CampainCriteriaScope);
                object[] arrobjDSData = CmUtils.ConvertUtils.DataSet2Array(dsData);
                ///////////////
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);


                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Mst_CampainCriteria_Save(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , strTid // strTid
                    , strSessionId // strSessionId
                                   ////
                    , objFlagIsDelete
                    //, object objFlagCheck_LimitPrd
                    ////
                    , objCampaignCrCode
                    , objCampaignCrName
                    , objCampainCriteriaType
                    , arrobjDSData
                    ));
                dtTable0 = mdsResult.Tables[0];

                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }
            }
            #endregion

            #region // Aud_Campaign:
            if (bTest)
            {
                ////
                object objFlagIsDelete = "0"; // 1 => Clear Exist, 0 => Clear + Insert
                object objCampaignCode = "AC20220912.999999";
                object objCampaignCrCode = "DZUNGND.IF_ACSINNO.01"; // Phải tạo Tiêu chuẩn chiến dịch trước
                object objCrtrScoreVerCode = "VER1.0";
                object objCrtrScoreVerAUCode = "VER1.0";
                object objCampaignName = "ThangPV_Campaign";
                object objEffDTimeStart = "2023-09-09";
                object objEffDTimeEnd = "2023-09-10";
                object objQtyCheck = "3";
                object objQtySuccess = "1";
                object objMinIntervalDays = "1";
                object objReportEndDate = "3";

                DataSet dsData = new DataSet();

                ////
                DataTable dtData_Aud_CampaignDoc = new DataTable("Aud_CampaignDoc");
                dtData_Aud_CampaignDoc.Columns.Add("FilePath", typeof(object));

                ////
                dtData_Aud_CampaignDoc.Rows.Add("/UploadFile/MrThang.png");

                ////
                DataTable dtData_Aud_CampaignDBPOSMDtl = new DataTable("Aud_CampaignDBPOSMDtl");
                dtData_Aud_CampaignDBPOSMDtl.Columns.Add("DBCode", typeof(object));
                dtData_Aud_CampaignDBPOSMDtl.Columns.Add("POSMCode", typeof(object));
                dtData_Aud_CampaignDBPOSMDtl.Columns.Add("QtyDeliver", typeof(object));

                ////
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN001", "GB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN001", "GH", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN001", "HT", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN001", "KB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN001", "TT", "1000");

                ////
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN002", "GB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN002", "GH", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN002", "HT", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN002", "KB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN002", "TT", "1000");

                ////
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN003", "GB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN003", "GH", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN003", "HT", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN003", "KB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN003", "TT", "1000");

                ////
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN004", "GB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN004", "GH", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN004", "HT", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN004", "KB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN004", "TT", "1000");

                ////
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN005", "GB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN005", "GH", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN005", "HT", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN005", "KB", "1000");
                dtData_Aud_CampaignDBPOSMDtl.Rows.Add("DBVN005", "TT", "1000");

                ////
                dsData.Tables.Add(dtData_Aud_CampaignDoc);
                dsData.Tables.Add(dtData_Aud_CampaignDBPOSMDtl);
                object[] arrobjDSData = CmUtils.ConvertUtils.DataSet2Array(dsData);

                ////
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);


                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Aud_Campaign_Save(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , strTid // strTid
                    , strSessionId // strSessionId
                                   ////
                    , objFlagIsDelete
                    ////
                    , objCampaignCode
                    , objCampaignCrCode
                    , objCrtrScoreVerCode
                    , objCrtrScoreVerAUCode
                    , objCampaignName
                    , objEffDTimeStart
                    , objEffDTimeEnd
                    , objQtyCheck
                    , objQtySuccess
                    , objMinIntervalDays
                    , objReportEndDate
                    , arrobjDSData
                    ));
                dtTable0 = mdsResult.Tables[0];
                MessageBox.Show("Success!");

                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }
            }

            if (bTest)
            {
                ////
                object objFlagIsDelete = "0"; // 1 => Clear Exist, 0 => Clear + Insert
                object objCampaignCode = "AC20220912.999999";
                object objRemark = "Remark Approve";
                ////
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);


                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Aud_Campaign_Approve(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , strTid // strTid
                    , strSessionId // strSessionId
                                   ////
                    , objFlagIsDelete
                    , objCampaignCode
                    , objRemark
                    ));
                dtTable0 = mdsResult.Tables[0];
                MessageBox.Show("Success!");

                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }
            }

            if (bTest)
            {
                ////
                object objFlagIsDelete = "0"; // 1 => Clear Exist, 0 => Clear + Insert
                object objCampaignCode = "AC20220912.999999";
                object objRemark = "Remark Cancel";
                ////
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);


                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Aud_Campaign_Cancel(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , strTid // strTid
                    , strSessionId // strSessionId
                                   ////
                    , objFlagIsDelete
                    , objCampaignCode
                    , objRemark
                    ));
                dtTable0 = mdsResult.Tables[0];
                MessageBox.Show("Success!");

                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }
            }
            #endregion

            #region // Aud_CampaignDBReceive:
            if (!bTest)
            {
                ////
                object objFlagIsDelete = "0"; // 1 => Clear Exist, 0 => Clear + Insert
                object objCampaignCode = "AC20220912.999999";
                object objDBReceiveNo = "DBReceiveNo.999999v1";

                DataSet dsData = new DataSet();

                ////  
                DataTable dtData_Aud_CampaignDBReceive = new DataTable("Aud_CampaignDBReceive");
                dtData_Aud_CampaignDBReceive.Columns.Add("DBCode", typeof(object));
                dtData_Aud_CampaignDBReceive.Columns.Add("POSMCode", typeof(object));
                dtData_Aud_CampaignDBReceive.Columns.Add("QtyDBRec", typeof(object));

                ////
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN001", "GB", "500");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN001", "GH", "600");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN001", "HT", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN001", "KB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN001", "TT", "400");

                ////
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN002", "GB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN002", "GH", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN002", "HT", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN002", "KB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN002", "TT", "400");

                ////
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN003", "GB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN003", "GH", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN003", "HT", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN003", "KB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN003", "TT", "400");

                ////
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN004", "GB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN004", "GH", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN004", "HT", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN004", "KB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN004", "TT", "400");

                ////
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN005", "GB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN005", "GH", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN005", "HT", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN005", "KB", "400");
                dtData_Aud_CampaignDBReceive.Rows.Add("DBVN005", "TT", "400");

                //// 
                dsData.Tables.Add(dtData_Aud_CampaignDBReceive);
                object[] arrobjDSData = CmUtils.ConvertUtils.DataSet2Array(dsData);

                ////
                string strTid = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMdd.HHmmss"), nSeq++);


                mdsResult = CmUtils.ConvertUtils.Array2DataSet(ws.Aud_CampaignDBReceive_Save(
                    strGwUserCode // strGwUserCode
                    , strGwPassword // strGwPassword
                    , strTid // strTid
                    , strSessionId // strSessionId
                                   ////
                    , objFlagIsDelete
                    ////
                    , objCampaignCode
                    , objDBReceiveNo
                    , arrobjDSData
                    ));
                dtTable0 = mdsResult.Tables[0];
                MessageBox.Show("Success!");

                if (CmUtils.CMyDataSet.HasError(mdsResult))
                {
                    CommonForms.Utils.ProcessMyDS(mdsResult);
                }
            }
            #endregion

            ////
            Thread.Sleep(10);
            ////

        }

        private void TestMix_SimpleLoop()
        {
            bool bTest = false;

            #region // Loop Table:
            if (!bTest)
            {
                ////
                DataTable dtData_InvF_AccessoryInExtDtl = new DataTable("InvF_AccessoryInExtDtl");
                dtData_InvF_AccessoryInExtDtl.Columns.Add("PartCode", typeof(object));
                dtData_InvF_AccessoryInExtDtl.Columns.Add("Qty", typeof(object));
                dtData_InvF_AccessoryInExtDtl.Columns.Add("Price", typeof(object));
                dtData_InvF_AccessoryInExtDtl.Columns.Add("Remark", typeof(object));

                ////
                dtData_InvF_AccessoryInExtDtl.Rows.Add("01-01-001", 20.5, 2000000, "1");
                dtData_InvF_AccessoryInExtDtl.Rows.Add("FF98", 10, 1000000, "1");
                dtData_InvF_AccessoryInExtDtl.Rows.Add("FF996", 10, 1000000, "1");
                dtData_InvF_AccessoryInExtDtl.Rows.Add("01-01-004", 10, 1000000, "1");
                dtData_InvF_AccessoryInExtDtl.Rows.Add("01-01-005", 10, 1000000, "1");

                //for (int nScan = 0; nScan < dtData_InvF_AccessoryInExtDtl.Rows.Count; nScan++)
                //{
                //	////
                //	DataRow drScan = dtData_InvF_AccessoryInExtDtl.Rows[nScan];

                //	string strPartCode = 
                //}
            }
            #endregion
        }

        #endregion

        private void ZTest_Load(object sender, EventArgs e)
        {

        }

    }
}
