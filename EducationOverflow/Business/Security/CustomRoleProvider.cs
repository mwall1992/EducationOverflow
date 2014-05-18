﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration.Provider;

namespace Business {

    public class CustomRoleProvider : System.Web.Security.RoleProvider {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            // TODO: find a more efficient method to query the database

            

            // check for invalid arguments
            foreach (string username in usernames) {
                CustomRoleProvider.ValidateUsername(username);
            }

            foreach (string roleName in roleNames) {
                CustomRoleProvider.ValidateRoleName(roleName);
            }

            //DataAccess.EducationOverflowTableAdapters.QueriesTableAdapter queriesTableAdapter =
            //    new DataAccess.EducationOverflowTableAdapters.QueriesTableAdapter();

            //queriesTableAdapter.AddRolesToUsers(new List<int>() { 3 }, new List<string>() { "admin" });

            //queriesTableAdapter.AddRolesToUsers(3, "admin");

            //DataAccess.EducationOverflowTableAdapters.QueriesTableAdapter queriesTableAdapater =
            //    new DataAccess.EducationOverflowTableAdapters.QueriesTableAdapter();

            //queriesTableAdapater.AddRolesToUsers(new string[] { "sally" }, new string[] { "user", "admin" });

            // TODO: Use transactions for insertion.

            //try {
            //    foreach (string username in usernames) {
            //        DataObjects.UserMembershipInfo userMembershipInfo =
            //            UserMembershipInfo.SelectUserMembershipInfo(username);

            //        foreach (string role in roleNames) {
            //            UserRoles.InsertUserRole(role, userMembershipInfo.UserId);
            //        }
            //    }
            //} catch (Exception e) {
            //    throw new ProviderException("Failed to add roles to users. Error message: " + e.Message);
            //}
        }

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
            CustomRoleProvider.ValidateRoleName(roleName);

            try {
                Role.InsertRole(roleName, null);
            } catch (Exception e) {
                throw new ProviderException("Failed to create role. Error message: " + e.Message);
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            // TODO: ensure cascade delete has been implemented.
            
            const int SUCCESSFUL_DELETE_COUNT = 1;
            bool roleDeleted = false;
            
            // validate role
            CustomRoleProvider.ValidateRoleName(roleName);
            if (Role.SelectRole(roleName) == null) {
                throw new ArgumentException("The specified role name does not exist.");
            }

            if (throwOnPopulatedRole) {
                throw new NotImplementedException();
            } else {
                roleDeleted = (Role.DeleteRole(roleName) == SUCCESSFUL_DELETE_COUNT);
            }

            return roleDeleted;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            List<DataObjects.Role> roles = Role.SelectRoles();

            string[] roleNames = new string[roles.Count];
            for (int i = 0; i < roles.Count; i++) {
                roleNames[i] = roles[i].Name;
            }

            return roleNames;
        }

        public override string[] GetRolesForUser(string username) {
            CustomRoleProvider.ValidateUsername(username);
            return UserRoles.SelectUserRoles(username).ToArray();
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {

            // validate the operation parameters
            CustomRoleProvider.ValidateRoleName(roleName);
            CustomRoleProvider.ValidateUsername(username);

            if (Role.SelectRole(roleName) == null) {
                throw new ProviderException("The specified role does not exist.");
            }

            if (UserMembershipInfo.SelectUserMembershipInfo(username) == null) {
                throw new ProviderException("The specified username does not exist.");
            }

            // determine if user has specified role
            bool isInRole = false;
            List<string> userRoles = UserRoles.SelectUserRoles(username);

            foreach (string role in userRoles) {
                if (role.Equals(roleName)) {
                    isInRole = true;
                    break;
                }
            }

            return isInRole;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            // TODO: find a more efficient method to query the database

            // check for invalid arguments
            foreach (string username in usernames) {
                CustomRoleProvider.ValidateUsername(username);
            }

            foreach (string roleName in roleNames) {
                CustomRoleProvider.ValidateRoleName(roleName);
            }

            // TODO: Use transactions for insertion.

            try {
                foreach (string username in usernames) {
                    DataObjects.UserMembershipInfo userMembershipInfo = 
                        UserMembershipInfo.SelectUserMembershipInfo(username);

                    foreach (string role in roleNames) {
                        UserRoles.DeleteUserRole(role, userMembershipInfo.UserId);
                    }
                }
            } catch (Exception e) {
                throw new ProviderException("Failed to remove roles from users. Error message: " + e.Message);
            }
        }

        public override bool RoleExists(string roleName) {
            CustomRoleProvider.ValidateRoleName(roleName);
            return (Role.SelectRole(roleName) != null);
        }

        // helper methods

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
