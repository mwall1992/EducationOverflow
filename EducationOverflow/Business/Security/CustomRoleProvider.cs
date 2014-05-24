using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration.Provider;

namespace Business {

    /// <summary>
    /// The role provider used for the Education Overflow Web application.
    /// </summary>
    /// <remarks>
    /// For detailed documentation of overriden methods in this class, consult 
    /// the class documentation for System.Web.Security.RoleProvider. Comments 
    /// have been included in this class only to document special 
    /// implementation details.
    /// </remarks>
    public class CustomRoleProvider : System.Web.Security.RoleProvider {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            // check for invalid arguments
            foreach (string username in usernames) {
                CustomRoleProvider.ValidateUsername(username);
            }

            foreach (string roleName in roleNames) {
                CustomRoleProvider.ValidateRoleName(roleName);
            }
            
            // retrieve user ids for usernames
            long[] userIds = new long[usernames.Length];
            for (int i = 0; i < usernames.Length; i++) {
                Data.EducationOverflow.UserMembershipRow memberInfo = UserMembership.SelectUserMembership(usernames[i]);
                if (memberInfo == null) {
                    throw new ProviderException("Specified username does not exist.");
                }

                userIds[i] = memberInfo.UserId;
            }

            // add user roles to data source
            try {
                UserRoles.InsertRolesForUsers(roleNames, userIds);
            } catch (Exception e) {
                throw new ProviderException("Failed to add roles to users. Error message: " + e.Message);
            }
        }

        /// <summary>
        /// Get and set the application name associated with the role provider.
        /// </summary>
        /// <remarks>
        /// The Education Overflow Web application does not currently use application
        /// names. As such, this property throws an exception if a value is set which is not
        /// equal to the current application name.
        /// </remarks>
        public override string ApplicationName {
            get {
                return CustomProvider.ApplicationName;
            }

            set {
                if (!value.Equals(CustomProvider.ApplicationName)) {
                    throw new ArgumentException("Modification of the Application Name is not supported.");
                }
            }
        }

        public override void CreateRole(string roleName) {
            const string ROLE_DESCRIPTION = null;
            CustomRoleProvider.ValidateRoleName(roleName);

            try {
                Role.InsertRole(roleName, ROLE_DESCRIPTION);
            } catch (Exception e) {
                throw new ProviderException("Failed to create role. Error message: " + e.Message);
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            bool roleDeleted = false;
            
            // validate role
            CustomRoleProvider.ValidateRoleName(roleName);
            if (Role.SelectRole(roleName) == null) {
                throw new ArgumentException("The specified role name does not exist.");
            }

            // attempt to delete the specified role
            if (throwOnPopulatedRole) {
                Data.EducationOverflow.UsersWithRoleDataTable usersInRole = UserRoles.SelectUsersWithRole(roleName);
                if (usersInRole.Count > 0) {
                    throw new ProviderException("Role deletion prevented because it was shared by users.");
                } else {
                    roleDeleted = this.DeleteRole(roleName);
                }
            } else {

                // TODO: replace with transaction.
                Data.EducationOverflow.UsersWithRoleDataTable usersWithRole = UserRoles.SelectUsersWithRole(roleName);
                foreach (Data.EducationOverflow.UsersWithRoleRow userWithRole in usersWithRole) {
                    UserRoles.DeleteUserRole(roleName, userWithRole.UserId);
                }

                roleDeleted = this.DeleteRole(roleName);
            }

            return roleDeleted;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            if (Role.SelectRole(roleName) == null) {
                throw new ProviderException("The specified role name does not exist.");
            }

            Data.EducationOverflow.MatchedUsersWithRoleDataTable usersInRole = 
                UserRoles.SelectMatchedUsersWithRole(roleName, usernameToMatch);

            string[] usernamesInRole = new string[usersInRole.Count];
            for (int i = 0; i < usersInRole.Count; i++) {
                usernamesInRole[i] = usersInRole[i].Username;
            }

            return usernamesInRole;
        }

        public override string[] GetAllRoles() {
            Data.EducationOverflow.RolesDataTable roles = Role.SelectRoles();

            string[] roleNames = new string[roles.Count];
            for (int i = 0; i < roles.Count; i++) {
                roleNames[i] = roles[i].Name;
            }

            return roleNames;
        }

        public override string[] GetRolesForUser(string username) {
            CustomRoleProvider.ValidateUsername(username);
                
            Data.EducationOverflow.UserRolesDataTable userRolesDataTable = 
                UserRoles.SelectUserRoles(username);

            string[] roles = new string[userRolesDataTable.Count];
            for (int i = 0; i < userRolesDataTable.Count; i++) {
                roles[i] = ((Data.EducationOverflow.UserRolesRow)userRolesDataTable.Rows[i]).RoleName;
            }

            return roles;
        }

        public override string[] GetUsersInRole(string roleName) {
            CustomRoleProvider.ValidateRoleName(roleName);

            if (Role.SelectRole(roleName) == null) {
                throw new ProviderException("The specified role name does not exist.");
            }

            Data.EducationOverflow.UsersWithRoleDataTable usersInRole = UserRoles.SelectUsersWithRole(roleName);

            string[] usernamesInRole = new string[usersInRole.Count];
            for (int i = 0; i < usersInRole.Count; i++) {
                usernamesInRole[i] = usersInRole[i].Username;
            }

            return usernamesInRole;
        }

        public override bool IsUserInRole(string username, string roleName) {
            // validate the operation parameters
            CustomRoleProvider.ValidateRoleName(roleName);
            CustomRoleProvider.ValidateUsername(username);

            if (Role.SelectRole(roleName) == null) {
                throw new ProviderException("The specified role does not exist.");
            }

            if (UserMembership.SelectUserMembership(username) == null) {
                throw new ProviderException("The specified username does not exist.");
            }

            // determine if user has specified role
            bool isInRole = false;
            Data.EducationOverflow.UserRolesDataTable userRoles = UserRoles.SelectUserRoles(username);

            foreach (Data.EducationOverflow.UserRolesRow roleRow in userRoles) {
                if (roleRow.RoleName.Equals(roleName)) {
                    isInRole = true;
                    break;
                }
            }

            return isInRole;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            // check for invalid arguments
            foreach (string username in usernames) {
                CustomRoleProvider.ValidateUsername(username);
            }

            foreach (string roleName in roleNames) {
                CustomRoleProvider.ValidateRoleName(roleName);
            }

            // retrieve user ids for usernames
            long[] userIds = new long[usernames.Length];
            for (int i = 0; i < usernames.Length; i++) {
                Data.EducationOverflow.UserMembershipRow memberInfo = UserMembership.SelectUserMembership(usernames[i]);
                if (memberInfo == null) {
                    throw new ProviderException("Specified username does not exist.");
                }

                userIds[i] = memberInfo.UserId;
            }

            // remove user roles from data source
            try {
                UserRoles.DeleteRolesFromUsers(roleNames, userIds);
            } catch (Exception e) {
                throw new ProviderException("Failed to remove roles from users. Error message: " + e.Message);
            }
        }

        public override bool RoleExists(string roleName) {
            CustomRoleProvider.ValidateRoleName(roleName);
            return (Role.SelectRole(roleName) != null);
        }


        // helper methods


        /// <summary>
        /// Delete a role from the application.
        /// </summary>
        /// <param name="roleName">The name of the role to be deleted.</param>
        /// <returns>True if the role was successfully deleted; otherwise, false.</returns>
        private bool DeleteRole(string roleName) {
            const int SUCCESSFUL_DELETE_COUNT = 1;

            // attempt to delete the specified role
            bool roleDeleted;
            try {
                roleDeleted = (Role.DeleteRole(roleName) >= SUCCESSFUL_DELETE_COUNT);
            } catch {
                roleDeleted = false;
            }

            return roleDeleted;
        }

        /// <summary>
        /// Validate the format of a role name.
        /// </summary>
        /// <param name="roleName">The role name to be validated.</param>
        /// <remarks>
        /// This method throws exceptions in the event that a role name is invalid. Many abstract
        /// methods of System.Web.Security.RoleProvider require such exceptions to be thrown.
        /// </remarks>
        private static void ValidateRoleName(string roleName) {
            const string INVALID_ROLE_NAME = "";
            const string INVALID_ROLE_NAME_CHARACTER = ",";

            if (roleName == null) {
                throw new ArgumentNullException("Role names cannot be null.");
            } else if (roleName.Equals(INVALID_ROLE_NAME)) {
                throw new ProviderException("Empty strings cannot be specified for role names.");
            } else if (roleName.Contains(INVALID_ROLE_NAME_CHARACTER)) {
                throw new ProviderException("Role names cannot include commas.");
            }
        }

        /// <summary>
        /// Validate the format of a username.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <remarks>
        /// This method throws exceptions in the event that a username is invalid. Many abstract
        /// methods of System.Web.Security.RoleProvider require such exceptions to be thrown.
        /// </remarks>
        private static void ValidateUsername(string username) {
            const string INVALID_USERNAME = "";

            if (username == null) {
                throw new ArgumentNullException("Usernames cannot be null.");
            } else if (username.Equals(INVALID_USERNAME)) {
                throw new ProviderException("Empty strings cannot be specified for usernames.");
            }
        }
    }
}
