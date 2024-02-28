using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;
using PhotoSW.CF.DataLayer.BAL;
using System.Data;

namespace PhotoSW.IMIX.Business
{
    public class RolePermissionsBusniess
    {
        public List<PermissionRoleInfo> GetPermissionData(int RoleId)
        {
            var obj = baPermissionRoleInfo.GetPermissionRoleInfoData().Where(p => p.PS_User_Roles_Id == RoleId)
                 .Select(p => new PermissionRoleInfo
                 {

                     DG_Permission_Role_pkey = p.PS_Permission_Role_pkey,
                     DG_User_Roles_Id = p.PS_User_Roles_Id,
                     DG_Permission_Id = p.PS_Permission_Id,

                 }).ToList();
            return obj;
        }

        public bool AddUpdateRoleData(int pkey, int RoleId, string RoleName, string SyncCode, int ParentRoleId)
        {
            try
            {
                baRoleInfo baRoleInfo = new baRoleInfo();
                baRoleInfo.Id = RoleId;
                baRoleInfo.User_Role = RoleName;
                baRoleInfo.SyncCode = SyncCode;
                baRoleInfo.User_Roles_pkey = pkey;
                baRoleInfo.IsActive = true;
                if (baRoleInfo.User_Roles_pkey == 0)
                {
                    return baRoleInfo.Insert(baRoleInfo);
                }
                else
                {
                    return baRoleInfo.Update(baRoleInfo);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteRoleData(int RoleId)
        {
            return baRoleInfo.Delete(RoleId);

        }
        public List<PhotoSW.IMIX.Model.RoleInfo> GetChildUserData(int UserId)
        {
            try
            {
                var obj = baRoleInfo.GetRoleInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RoleInfo
                    {
                        DG_User_Roles_pkey = p.User_Roles_pkey,
                        DG_User_Role = p.User_Role,
                        SyncCode = p.SyncCode

                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.RoleInfo>();
            }
            // return new List<PhotoSW.IMIX.Model.RoleInfo>();
        }

        public List<PhotoSW.IMIX.Model.PermissionInfo> GetPermissionNames(string PermissionId,
            string PermissionName)
        {
            try
            {
                var obj = baPermissionInfo.GetPermissionInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.PermissionInfo
                    {
                        DG_Permission_pkey = p.PS_Permission_pkey,
                        DG_Permission_Name = p.PS_Permission_Name,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced

                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.PermissionInfo>();
            }
            // return new List<PhotoSW.IMIX.Model.PermissionInfo>();
        }
        public string GetRoleName(int roleID)
        {
            return "";
        }
        public List<PhotoSW.IMIX.Model.RoleInfo> GetRoleNames(int RoleId, string RoleName)
        {
            try
            {
                var obj = baRoleInfo.GetRoleInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RoleInfo
                    {
                        DG_User_Roles_pkey = p.User_Roles_pkey,
                        DG_User_Role = p.User_Role,
                        SyncCode = p.SyncCode

                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.RoleInfo>();
            }
            //  return new List<PhotoSW.IMIX.Model.RoleInfo>();
        }
        public bool RemovePermissionData(int RoleId, int PermissonId)
        {
            return false;
        }
        public bool SetPermissionData(int RoleId, int PermissonId)
        {
            return false;
        }
        public bool SetremovePermissionData(DataTable udt_Permission)
        {
            bool retval = false;
            try
            {
                var obj = udt_Permission;
                baPermissionRoleInfo baPermissionRoleInfo = new baPermissionRoleInfo();
                //db.PermissionRoleInfos.RemoveRange(db.PermissionRoleInfos.Where(v => v.PS_User_Roles_Id == permissionroleinfo.PS_User_Roles_Id));
                foreach (DataRow Row in obj.Rows)
                {
                    int ID = 0;
                    ID = Convert.ToInt32(Row["RoleId"]);
                    retval = baPermissionRoleInfo.ReSetAllPremission(ID);
                    break;
                }
                foreach (DataRow Row in obj.Rows)
                {
                    baPermissionRoleInfo.PS_User_Roles_Id = Convert.ToInt32(Row["RoleId"]);
                    //baPermissionRoleInfo.PS_Permission_Role_pkey = Convert.ToInt32(String.IsNullOrEmpty(Row["PermissonRolePKey"].ToString())?0: Row["PermissonRolePKey"]);
                    baPermissionRoleInfo.PS_Permission_Id = Convert.ToInt32(Row["PermissonId"]);
                    baPermissionRoleInfo.IsActive = Convert.ToBoolean(Row["IsAvailable"]);
                    //if (baPermissionRoleInfo.PS_Permission_Id == 0)
                    //{
                    retval = baPermissionRoleInfo.Insert(baPermissionRoleInfo);
                    //}
                    //else
                    //{
                    //    retval = baPermissionRoleInfo.Update(baPermissionRoleInfo);
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }

            /*
            dataTable.Columns.Add("RoleId", typeof(string));
                    dataTable.Columns.Add("PermissonId", typeof(string));
                    dataTable.Columns.Add("IsAvailable", typeof(bool));*/
            return retval;
        }
    }
}
