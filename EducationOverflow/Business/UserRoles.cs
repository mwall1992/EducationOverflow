using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class UserRoles {
        
        private static UserRolesTableAdapter userRolesTableAdapter = 
            new UserRolesTableAdapter();

        private static UserMembershipInfoTableAdapter userMembershipInfoTableAdapter =
            new UserMembershipInfoTableAdapter();

        private static QueriesTableAdapter queriesTableAdapter = 
            new QueriesTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectUserRoles(string username) {
            DataAccess.EducationOverflow.UserMembershipInfoDataTable userMemberDataTable =
                userMembershipInfoTableAdapter.GetData(username);

            List<string> roles = new List<string>();
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipInfoRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipInfoRow)userMemberDataTable.Rows[0];

                DataAccess.EducationOverflow.UserRolesDataTable userRolesDataTable =
                    userRolesTableAdapter.GetData(memberInfoRow.UserId);

                foreach (DataAccess.EducationOverflow.UserRolesRow row in userRolesDataTable.Rows) {
                    roles.Add(row.RoleName);
                }
            }

            return roles;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUserRole(string roleName, long userId) {
            userRolesTableAdapter.Insert(roleName, userId);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUserRole(string roleName, long userId, string originalRoleName, 
                long originalUserId) {
            userRolesTableAdapter.Update(roleName, userId, originalRoleName, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteUserRole(string originalRoleName, long originalUserId) {
            userRolesTableAdapter.Delete(originalRoleName, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertRolesForUsers(string[] roleNames, long[] userIds) {
            DataAccess.EducationOverflow.UserIdsDataTable userIdsDataTable = 
                new DataAccess.EducationOverflow.UserIdsDataTable();
            foreach (long userId in userIds) {
                userIdsDataTable.AddUserIdsRow(userId);
            }

            DataAccess.EducationOverflow.RoleNamesDataTable roleNamesDataTable = 
                new DataAccess.EducationOverflow.RoleNamesDataTable();
            foreach (string roleName in roleNames) {
                roleNamesDataTable.AddRoleNamesRow(roleName);
            }

            queriesTableAdapter.AddRolesToUsers(userIdsDataTable, roleNamesDataTable);
        }
    }
}
