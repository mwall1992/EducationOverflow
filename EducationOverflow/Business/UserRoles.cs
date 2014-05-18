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

        private static UserMembershipTableAdapter userMembershipInfoTableAdapter =
            new UserMembershipTableAdapter();

        private static QueriesTableAdapter queriesTableAdapter = 
            new QueriesTableAdapter();

        private static UsersWithRoleTableAdapter usersWithRoleTableAdapter = 
            new UsersWithRoleTableAdapter();

        private static MatchedUsersWithRoleTableAdapter matchedUsersWithRoleTableAdapter = 
            new MatchedUsersWithRoleTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectUserRoles(string username) {
            DataAccess.EducationOverflow.UserMembershipDataTable userMemberDataTable =
                userMembershipInfoTableAdapter.GetData(username);

            List<string> roles = new List<string>();
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipRow)userMemberDataTable.Rows[0];

                DataAccess.EducationOverflow.UserRolesDataTable userRolesDataTable =
                    userRolesTableAdapter.GetData(memberInfoRow.UserId);

                foreach (DataAccess.EducationOverflow.UserRolesRow row in userRolesDataTable.Rows) {
                    roles.Add(row.RoleName);
                }
            }

            return roles;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.UserIdentifier> SelectUsersWithRole(string roleName) {
            DataAccess.EducationOverflow.UsersWithRoleDataTable usersWithRoleDataTable =
                usersWithRoleTableAdapter.GetData(roleName);

            List<DataObjects.UserIdentifier> userIdentifiers = new List<DataObjects.UserIdentifier>();
            foreach (DataAccess.EducationOverflow.UsersWithRoleRow row in usersWithRoleDataTable.Rows) {
                userIdentifiers.Add(new DataObjects.UserIdentifier() {
                    UserId = row.UserId,
                    Username = row.Username
                });
            }

            return userIdentifiers;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.UserIdentifier> SelectMatchedUsersWithRole(string roleName, string matchedUsername) {
            DataAccess.EducationOverflow.MatchedUsersWithRoleDataTable matchedUsersWithRoleDataTable =
                matchedUsersWithRoleTableAdapter.GetData(roleName, matchedUsername);

            List<DataObjects.UserIdentifier> userIdentifiers = new List<DataObjects.UserIdentifier>();
            foreach (DataAccess.EducationOverflow.UsersWithRoleRow row in matchedUsersWithRoleDataTable.Rows) {
                userIdentifiers.Add(new DataObjects.UserIdentifier() {
                    UserId = row.UserId,
                    Username = row.Username
                });
            }

            return userIdentifiers;
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

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteRolesFromUsers(string[] roleNames, long[] userIds) {
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

            queriesTableAdapter.RemoveRolesFromUsers(userIdsDataTable, roleNamesDataTable);
        }
    }
}
