using System;
using System.Collections;
using System.Data;
//using System.Xml.Linq;

using CmUtils = CommonUtils;
using TConst = Demo.Lab.Constants;
using TDALUtils = EzDAL.Utils;
using TError = Demo.Lab.Errors;
using TUtils = Demo.Lab.Utils;



namespace Demo.Lab.Biz
{
	public partial class BizDemoLab
	{
		#region // Mst_CampainCriteria_CheckDB
		private void Mst_CampainCriteria_CheckDB(
			ref ArrayList alParamsCoupleError
			, object objCampaignCrCode
			, string strFlagExistToCheck
			, string strFlagActiveListToCheck
			, out DataTable dtDB_Mst_CampainCriteria
			)
		{
			// GetInfo:
			string strSqlExec = CmUtils.StringUtils.Replace(@"
					select top 1
						t.*
					from Mst_CampainCriteria t --//[mylock]
					where (1=1)
						and t.CampaignCrCode = @objCampaignCrCode
					;
				");
			dtDB_Mst_CampainCriteria = _cf.db.ExecQuery(
				strSqlExec
				, "@objCampaignCrCode", objCampaignCrCode
				).Tables[0];
			dtDB_Mst_CampainCriteria.TableName = "Mst_CampainCriteria";

			// strFlagExistToCheck:
			if (strFlagExistToCheck.Length > 0)
			{
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Active) && dtDB_Mst_CampainCriteria.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CampaignCrCode", objCampaignCrCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CampainCriteria_CheckDB_CampainCriteriaNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Inactive) && dtDB_Mst_CampainCriteria.Rows.Count > 0)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CampaignCrCode", objCampaignCrCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CampainCriteria_CheckDB_CampainCriteriaExist
						, null
						, alParamsCoupleError.ToArray()
						);
				}
			}

			// strFlagActiveListToCheck:
			if (strFlagActiveListToCheck.Length > 0 && !strFlagActiveListToCheck.Contains(Convert.ToString(dtDB_Mst_CampainCriteria.Rows[0]["FlagActive"])))
			{
				alParamsCoupleError.AddRange(new object[]{
					"Check.CampaignCrCode", objCampaignCrCode
					, "Check.strFlagActiveListToCheck", strFlagActiveListToCheck
					, "DB.FlagActive", dtDB_Mst_CampainCriteria.Rows[0]["FlagActive"]
					});
				throw CmUtils.CMyException.Raise(
					TError.ErrDemoLab.Mst_CampainCriteria_CheckDB_FlagActiveNotMatched
					, null
					, alParamsCoupleError.ToArray()
					);
			}
		}
		#endregion

		#region // Mst_CampainCriteria_Save
		public DataSet Mst_CampainCriteria_Save(
			string strTid
			, DataRow drSession
			////
			, object objFlagIsDelete
			////
			, object objCampaignCrCode
			, object objCampaignCrName
			, object objCampainCriteriaType
			, object[] arrobjDSData
			)
		{
			#region // Temp:
			DataSet mdsFinal = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			//int nTidSeq = 0;
			bool bMyDebugSql = false;
			DateTime dtimeSys = DateTime.Now;
			bool bNeedTransaction = true;
			string strFunctionName = "Mst_CampainCriteria_Save";
			string strErrorCodeDefault = TError.ErrDemoLab.Mst_CampainCriteria_Save;
			ArrayList alParamsCoupleError = new ArrayList(new object[]{
				"strFunctionName", strFunctionName
				, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
			    ////
			    , "objFlagIsDelete", objFlagIsDelete
			    ////
			    , "objCampaignCrCode", objCampaignCrCode
				, "objCampaignCrName", objCampaignCrName
				, "objCampainCriteriaType", objCampainCriteriaType
				});
			//ArrayList alPCErrEx = new ArrayList();
			#endregion

			try
			{
				#region // Convert Input:
				DataSet dsData = TUtils.CUtils.StdDS(arrobjDSData);
				if (dsData == null) dsData = new DataSet("dsData");
				dsData.AcceptChanges();
				alParamsCoupleError.AddRange(new object[]{
					 "Check.dsData", CmUtils.XmlUtils.DataSet2XmlSimple(dsData)
					 });
				#endregion

				#region // Init:
				_cf.db.LogUserId = _cf.sinf.strUserCode;
				if (bNeedTransaction) _cf.db.BeginTransaction();

				// Write RequestLog:
				_cf.ProcessBizReq(
					strTid // strTid
					, strFunctionName // strFunctionName
					, alParamsCoupleError // alParamsCoupleError
					);

				// Check Access/Deny:
				Sys_Access_CheckDeny(
					ref alParamsCoupleError
					, strFunctionName
					);
				#endregion

				#region //// Refine and Check Mst_CampainCriteria:
				////
				bool bIsDelete = CmUtils.StringUtils.StringEqual(objFlagIsDelete, TConst.Flag.Active);
				////
				string strCampaignCrCode = TUtils.CUtils.StdParam(objCampaignCrCode);
				string strCampaignCrName = string.Format("{0}", objCampaignCrName).Trim();
				string strCampainCriteriaType = string.Format("{0}", objCampainCriteriaType).Trim();
				string strCreateDTime = null;
				string strCreateBy = null;

				////
				DataTable dtDB_Mst_CampainCriteria = null;
				{

					Mst_CampainCriteria_CheckDB(
						ref alParamsCoupleError // alParamsCoupleError
						, strCampaignCrCode // objCampaignCrCode
						, "" // strFlagExistToCheck
						, "" // strStatusListToCheck
						, out dtDB_Mst_CampainCriteria // dtDB_Mst_CampainCriteria
						);
					if (dtDB_Mst_CampainCriteria.Rows.Count < 1) // Chưa Tồn tại Order.
					{
						if (bIsDelete)
						{
							goto MyCodeLabel_Done; // Thành công.
						}
						else
						{
							// Nothing.
						}
					}
					else // Đã Tồn tại.
					{

						strCreateDTime = TUtils.CUtils.StdDTime(dtDB_Mst_CampainCriteria.Rows[0]["CreateDTime"]);
						strCreateBy = TUtils.CUtils.StdParam(dtDB_Mst_CampainCriteria.Rows[0]["CreateBy"]);
					}
					////
					strCreateDTime = string.IsNullOrEmpty(strCreateDTime) ? dtimeSys.ToString("yyyy-MM-dd HH:mm:ss") : strCreateDTime;
					strCreateBy = string.IsNullOrEmpty(strCreateBy) ? _cf.sinf.strUserCode : strCreateBy;
					////
					if (strCampaignCrName == null || strCampaignCrName.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCampaignCrName", strCampaignCrName
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Mst_CampainCriteria_Save_InvalidCampaignCrName
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					if (strCampainCriteriaType == null || strCampainCriteriaType.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCampainCriteriaType", strCampainCriteriaType
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Mst_CampainCriteria_Save_InvalidCampainCriteriaType
							, null
							, alParamsCoupleError.ToArray()
							);
					}
				}
				////
				#endregion

				#region //// SaveTemp Mst_CampainCriteria:
				if (!bIsDelete)
				{
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Mst_CampainCriteria"
						, new object[]{
							"CampaignCrCode", TConst.BizMix.Default_DBColType,
							"CampaignCrName", TConst.BizMix.Default_DBColType,
							"CampainCriteriaType", TConst.BizMix.Default_DBColType,
							"CreateDTime", TConst.BizMix.Default_DBColType,
							"CreateBy", TConst.BizMix.Default_DBColType,
							"FlagActive", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, new object[]{
							new object[]{
								strCampaignCrCode,                          // CampaignCrCode
						        strCampaignCrName,                          // CampaignCrName
						        strCampainCriteriaType,                     // CampainCriteriaType 
						        strCreateDTime,                             // CreateDTime
						        strCreateBy,                                // CreateBy
                                TConst.Flag.Active,                         // FlagActive   
						        dtimeSys.ToString("yyyy-MM-dd HH:mm:ss"),   // LogLUDTime
						        _cf.sinf.strUserCode,                       // LogLUBy
						        }
							}
						);
				}
				#endregion

				#region //// Refine and Check Mst_CampainCriteriaScope:
				////
				DataTable dtInput_Mst_CampainCriteriaScope = null;
				if (!bIsDelete)
				{
					////
					string strTableCheck = "Mst_CampainCriteriaScope";
					////
					if (!dsData.Tables.Contains(strTableCheck))
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.TableName", strTableCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Mst_CampainCriteria_Save_Input_CampainCriteriaScopeTblNotFound
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					dtInput_Mst_CampainCriteriaScope = dsData.Tables[strTableCheck];
					////
					TUtils.CUtils.StdDataInTable(
						dtInput_Mst_CampainCriteriaScope         // dtData
						, "StdParam", "SSGrpCode"                // arrstrCouple 
						, "StdParam", "SSBrandCode"              // arrstrCouple  
						, "StdParam", "CampainCritScopeDesc"     // arrstrCouple  
						, "StdParam", "LevelCode"                // arrstrCouple  
						);
					////

					TUtils.CUtils.MyForceNewColumn(ref dtInput_Mst_CampainCriteriaScope, "CampaignCrCode", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Mst_CampainCriteriaScope, "FlagActive", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Mst_CampainCriteriaScope, "LogLUDTime", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Mst_CampainCriteriaScope, "LogLUBy", typeof(object));
					////
					for (int nScan = 0; nScan < dtInput_Mst_CampainCriteriaScope.Rows.Count; nScan++)
					{
						////
						DataRow drScan = dtInput_Mst_CampainCriteriaScope.Rows[nScan];

						////
						DataTable dtDB_Mst_StarShopGroup = null;

						Mst_StarShopGroup_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError 
							, drScan["SSGrpCode"] // objSSGrpCode 
							, TConst.Flag.Yes // strFlagExistToCheck
							, "" // strStatusListToCheck
							, out dtDB_Mst_StarShopGroup // dtDB_Mst_StarShopGroup
							);
						////
						DataTable dtDB_Mst_StarShopBrand = null;

						Mst_StarShopBrand_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, drScan["SSBrandCode"] // objSSBrandCode 
							, TConst.Flag.Yes // strFlagExistToCheck							
							, "" // strStatusListToCheck
							, out dtDB_Mst_StarShopBrand // dtDB_Mst_StarShopBrand
							);
						////
						DataTable dtDB_Mst_StarShopType = null;

						Mst_StarShopType_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, drScan["SSGrpCode"] // objSSGrpCode
							, drScan["SSBrandCode"] // objSSBrandCode 
							, TConst.Flag.Yes // strFlagExistToCheck							
							, "" // strStatusListToCheck
							, out dtDB_Mst_StarShopType // dtDB_Mst_StarShopType
							);
						//// 
						string strLevelCode = string.Format("{0}", drScan["LevelCode"]).Trim();
						if (strLevelCode.Length < 1)
						{
							alParamsCoupleError.AddRange(new object[]{
							"Check.strLevelCode", strLevelCode
							});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Mst_CampainCriteriaScope_Save_InvalidLevelCode
								, null
								, alParamsCoupleError.ToArray()
								);
						}

						////
						drScan["CampaignCrCode"] = strCampaignCrCode;
						drScan["FlagActive"] = TConst.Flag.Active;
						drScan["LogLUDTime"] = dtimeSys.ToString("yyyy-MM-dd HH:mm:ss");
						drScan["LogLUBy"] = _cf.sinf.strUserCode;
						////
					}
				}
				#endregion

				#region //// SaveTemp Mst_CampainCriteriaScope:
				if (!bIsDelete)
				{
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Mst_CampainCriteriaScope"
						, new object[]{
							"CampaignCrCode", TConst.BizMix.Default_DBColType,
							"SSGrpCode", TConst.BizMix.Default_DBColType,
							"SSBrandCode", TConst.BizMix.Default_DBColType,
							"LevelCode", TConst.BizMix.Default_DBColType,
							"CampainCritScopeDesc", TConst.BizMix.Default_DBColType,
							"FlagActive", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, dtInput_Mst_CampainCriteriaScope
						);
				}
				#endregion

				#region //// Save
				//// Clear All:
				{
					string strSqlDelete = CmUtils.StringUtils.Replace(@"
						        ---- Mst_CampainCriteria:
						        delete t
						        from Mst_CampainCriteria t --//[mylock]
						        where (1=1)
							        and t.CampaignCrCode = @strCampaignCrCode
						        ;

						        ---- Mst_CampainCriteriaScope:
						        delete t
						        from Mst_CampainCriteriaScope t --//[mylock]
						        where (1=1)
							        and t.CampaignCrCode = @strCampaignCrCode
						        ;

					        ");
					_cf.db.ExecQuery(
						strSqlDelete
						, "@strCampaignCrCode", strCampaignCrCode
						);
				}
				//// Insert All:
				if (!bIsDelete)
				{
					////
					string zzzzClauseInsert_Mst_CampainCriteria_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Mst_CampainCriteria:
					        insert into Mst_CampainCriteria
					        (
						        CampaignCrCode
						        , CampaignCrName
						        , CampainCriteriaType
						        , CreateDTime
						        , CreateBy
                                , FlagActive
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCrCode
						        , t.CampaignCrName
						        , t.CampainCriteriaType
						        , t.CreateDTime
						        , t.CreateBy
						        , t.FlagActive
						        , t.LogLUDTime
						        , t.LogLUBy
					        from #input_Mst_CampainCriteria t --//[mylock]
					        ;
				        ");
					////
					string zzzzClauseInsert_Mst_CampainCriteriaScope_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Mst_CampainCriteriaScope:
					        insert into Mst_CampainCriteriaScope
					        (
						        CampaignCrCode
						        , SSGrpCode
						        , SSBrandCode
						        , LevelCode
						        , CampainCritScopeDesc
						        , FlagActive
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCrCode
						        , t.SSGrpCode
						        , t.SSBrandCode
						        , t.LevelCode
						        , t.CampainCritScopeDesc
						        , t.FlagActive
						        , t.LogLUDTime
						        , t.LogLUBy
					        from #input_Mst_CampainCriteriaScope t --//[mylock]
					        ;
				        ");
					////
					string strSqlExec = CmUtils.StringUtils.Replace(@"
					        ----
					        zzzzClauseInsert_Mst_CampainCriteria_zSave
					        ----
					        zzzzClauseInsert_Mst_CampainCriteriaScope_zSave
					        ----
				        "
						, "zzzzClauseInsert_Mst_CampainCriteria_zSave", zzzzClauseInsert_Mst_CampainCriteria_zSave
						, "zzzzClauseInsert_Mst_CampainCriteriaScope_zSave", zzzzClauseInsert_Mst_CampainCriteriaScope_zSave
						);
					////
					if (bMyDebugSql)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strSqlExec", strSqlExec
							});
					}
					DataSet dsExec = _cf.db.ExecQuery(strSqlExec);
				}
			#endregion

			// Return Good:
			MyCodeLabel_Done:
				TDALUtils.DBUtils.CommitSafety(_cf.db);
				mdsFinal.AcceptChanges();
				return mdsFinal;
			}
			catch (Exception exc)
			{
				#region // Catch of try:
				// Rollback:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);

				// Return Bad:
				//alParamsCoupleError.AddRange(alPCErrEx);
				return TUtils.CProcessExc.Process(
					ref mdsFinal
					, exc
					, strErrorCodeDefault
					, alParamsCoupleError.ToArray()
					);
				#endregion
			}
			finally
			{
				#region // Finally of try:
				// Rollback and Release resources:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);
				TDALUtils.DBUtils.ReleaseAllSemaphore(_cf.db_Sys, true);

				// Write ReturnLog:
				_cf.ProcessBizReturn(
					ref mdsFinal // mdsFinal
					, strTid // strTid
					, strFunctionName // strFunctionName
					);
				#endregion
			}
		}
		#endregion
	}
}
