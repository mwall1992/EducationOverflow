using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with the roles of users.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the custom role provider class for managing role information.
    /// </remarks>
    [DataObject]
    public class UserRoles {

        /// <summary>
        /// The table adapter used for user role information.
        /// </summary>
        private static UserRolesTableAdapter userRolesTableAdapter = 
            new UserRolesTableAdapter();

        /// <summary>
        /// The table adapter used for user membership information.
        /// </summary>
        private static UserMembershipTableAdapter userMembershipInfoTableAdapter =
            new UserMembershipTableAdapter();

        /// <summary>
        /// The table adapter used for uncategorised queries.
        /// </summary>
        private static QueriesTableAdapter queriesTableAdapter = 
            new QueriesTableAdapter();

        /// <summary>
        /// The table adapter used for information on users with roles.
        /// </summary>
        private static UsersWithRoleTableAdapter usersWithRoleTableAdapter = 
            new UsersWithRoleTableAdapter();

        /// <summary>
        /// The table adapter used for information on matched users with roles.
        /// </summary>
        private static MatchedUsersWithRoleTableAdapter matchedUsersWithRoleTableAdapter = 
            new MatchedUsersWithRoleTableAdapter();

        /// <summary>
        /// Retrieve roles for a specific user.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>A table containing information on the roles owned by the specified user.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserRolesDataTable SelectUserRoles(string username) {
            const int FIRST_RECORD_INDEX = 0;
            
            Data.EducationOverflow.UserRolesDataTable roleInformation = null;
            Data.EducationOverflow.UserMembershipDataTable userMembershipDataTable = 
                userMembershipInfoTableAdapter.GetData(username);

            if (userMembershipDataTable != null) {
                roleInformation = 
                    userRolesTableAdapter.GetData(userMembershipDataTable[FIRST_RECORD_INDEX].UserId);
            }

            return roleInformation;
        }

        /// <summary>
        /// Retrieve users with a specific role.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <returns>A table containing information on the users with the specified role.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UsersWithRoleDataTable SelectUsersWithRole(string roleName) {
            return usersWithRoleTableAdapter.GetData(roleName);
        }

        /// <summary>
        /// Retrieve users with a specific role whose username matches a certain string.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <param name="matchedUsername">The username to be matched.</param>
        /// <returns>A table containing information of matched users who have the specified role.</returns>
        /// <remarks>
        /// For information on what counts as a matching username, see the RoleProvider class documentation.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.MatchedUsersWithRoleDataTable SelectMatchedUsersWithRole(string roleName, 
                string matchedUsername) {
            return matchedUsersWithRoleTableAdapter.GetData(roleName, matchedUsername);
        }

        /// <summary>
        /// Insert a role for a specific user.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserRole(string roleName, long userId) {
            return userRolesTableAdapter.Insert(roleName, userId);
        }

        /// <summary>
        /// Insert roles for users.
        /// </summary>
        /// <param name="roleNames">A list of role names.</param>
        /// <param name="userIds">A list of user ids.</param>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertRolesForUsers(string[] roleNames, long[] userIds) {
            Data.EducationOverflow.UserIdsDataTable userIdsDataTable =
                new Data.EducationOverflow.UserIdsDataTable();
            foreach (long userId in userIds) {
                userIdsDataTable.AddUserIdsRow(userId);
            }

            Data.EducationOverflow.RoleNamesDataTable roleNamesDataTable =
                new Data.EducationOverflow.RoleNamesDataTable();
            foreach (string roleName in roleNames) {
                roleNamesDataTable.AddRoleNamesRow(roleName);
            }

            queriesTableAdapter.AddRolesToUsers(userIdsDataTable, roleNamesDataTable);
        }

        /// <summary>
        /// Update the role of a specific user.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="originalRoleName">The original role name.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserRole(string roleName, long userId, string originalRoleName, 
                long originalUserId) {
            return userRolesTableAdapter.Update(roleName, userId, originalRoleName, originalUserId);
        }

        /// <summary>
        /// Delete the role of a specific user.
        /// </summary>
        /// <param name="originalRoleName">The original role name.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserRole(string originalRoleName, long originalUserId) {
            return userRolesTableAdapter.Delete(originalRoleName, originalUserId);
        }

        /// <summary>
        /// Delete roles for users.
        /// </summary>
        /// <param name="roleNames">A list of role names.</param>
        /// <param name="userIds">A list of user ids.</param>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteRolesFromUsers(string[] roleNames, long[] userIds) {
            Data.EducationOverflow.UserIdsDataTable userIdsDataTable =
                new Data.EducationOverflow.UserIdsDataTable();
            foreach (long userId in userIds) {
                userIdsDataTable.AddUserIdsRow(userId);
            }

            Data.EducationOverflow.RoleNamesDataTable roleNamesDataTable =
                new Data.EducationOverflow.RoleNamesDataTable();
            foreach (string roleName in roleNames) {
                roleNamesDataTable.AddRoleNamesRow(roleName);
            }

            queriesTableAdapter.RemoveRolesFromUsers(userIdsDataTable, roleNamesDataTable);
        }
    }
}
