using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business {

    public class CustomRoleProvider : System.Web.Security.RoleProvider {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            // TODO: find a more efficient method to query the database

            foreach (string username in usernames) {
                DataObjects.UserMembershipInfo userMembershipInfo =
                    UserMembershipInfo.SelectUserMembershipInfo(username);

                foreach (string role in roleNames) {
                    UserRoles.InsertUserRole(role, userMembershipInfo.UserId);
                }
            }
        }

        public override string ApplicationName {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName) {
            Role.InsertRole(roleName, null);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            const int SUCCESSFUL_DELETE_COUNT = 1;
            bool roleDeleted = false;

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
            return UserRoles.SelectUserRoles(username).ToArray();
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
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

            foreach (string username in usernames) {
                DataObjects.UserMembershipInfo userMembershipInfo = 
                    UserMembershipInfo.SelectUserMembershipInfo(username);

                foreach (string role in roleNames) {
                    UserRoles.DeleteUserRole(role, userMembershipInfo.UserId);
                }
            }
        }

        public override bool RoleExists(string roleName) {
            return (Role.SelectRole(roleName) != null);
        }
    }
}
