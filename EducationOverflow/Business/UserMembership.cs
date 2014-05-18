﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class UserMembership {

        private static UserMembershipTableAdapter membershipTableAdapter =
            new UserMembershipTableAdapter();

        private static UserMembershipWithoutPasswordTableAdapter membershipWithoutPasswordTableAdapter = 
            new UserMembershipWithoutPasswordTableAdapter();

        private static AllUserMembershipTableAdapter allUserMembershipTableAdapter = 
            new AllUserMembershipTableAdapter();

        private static UserMembershipForEmailTableAdapter userMembershipForEmailTableAdapter =
            new UserMembershipForEmailTableAdapter();

        private static UserMembershipMatchingEmailTableAdapter userMembershipMatchingEmailTableAdapter =
             new UserMembershipMatchingEmailTableAdapter();

        private static UserMembershipMatchingUsernameTableAdapter membershipMatchingUsernameTableAdapter = 
            new UserMembershipMatchingUsernameTableAdapter();

        private static UserMembershipForUserIdTableAdapter membershipForUserIdTableAdapter = 
            new UserMembershipForUserIdTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembership SelectUserMembership(string username) {
            DataAccess.EducationOverflow.UserMembershipDataTable userMemberDataTable =
                membershipTableAdapter.GetData(username);

            DataObjects.UserMembership memberInfo = null;
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipRow)userMemberDataTable.Rows[0];

                memberInfo = new DataObjects.UserMembership() {
                    UserId = memberInfoRow.UserId,
                    Username = memberInfoRow.Username,
                    ApplicationName = memberInfoRow.ApplicationName,
                    Email = memberInfoRow.Email,
                    IsLocked = memberInfoRow.IsLocked,
                    LastActivityDate = memberInfoRow.LastActivityDate
                };
            }

            return memberInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembership SelectUserMembershipForUserId(long userId) {
            DataAccess.EducationOverflow.UserMembershipForUserIdDataTable userMemberDataTable =
                membershipForUserIdTableAdapter.GetData(userId);

            DataObjects.UserMembership memberInfo = null;
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipForUserIdRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipForUserIdRow)userMemberDataTable.Rows[0];

                memberInfo = new DataObjects.UserMembership() {
                    UserId = memberInfoRow.UserId,
                    Username = memberInfoRow.Username,
                    ApplicationName = memberInfoRow.ApplicationName,
                    Email = memberInfoRow.Email,
                    IsLocked = memberInfoRow.IsLocked,
                    LastActivityDate = memberInfoRow.LastActivityDate, 
                    IsApproved = memberInfo.IsApproved,
                    LastPasswordChangeDate = memberInfo.LastPasswordChangeDate,
                    CreationDate = memberInfo.CreationDate,
                    LastLockedOutDate = memberInfo.LastLockedOutDate,
                    Comment = memberInfo.Comment,
                    PasswordQuestion = memberInfo.PasswordQuestion,
                    PasswordAnswer = memberInfo.PasswordAnswer
                };
            }

            return memberInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static string SelectPassword(string username) {
            string password = null;
            DataAccess.EducationOverflow.UserMembershipDataTable userMemberDataTable =
                membershipTableAdapter.GetData(username);

            if (userMemberDataTable.Count > 0) {
                DataAccess.EducationOverflow.UserMembershipRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipRow)userMemberDataTable.Rows[0];

                password = memberInfoRow.Password;
            }

            return password;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.UserMembership> SelectAllUserMembership() {
            List<DataObjects.UserMembership> allUserMembership = new List<DataObjects.UserMembership>();
            DataAccess.EducationOverflow.AllUserMembershipDataTable userMemberDataTable =
                allUserMembershipTableAdapter.GetData();

            foreach (DataAccess.EducationOverflow.AllUserMembershipRow row in userMemberDataTable.Rows) {
                allUserMembership.Add(new DataObjects.UserMembership() {
                    UserId = row.UserId,
                    Username = row.Username,
                    ApplicationName = row.ApplicationName,
                    Email = row.Email,
                    IsLocked = row.IsLocked,
                    LastActivityDate = row.LastActivityDate
                });
            }

            return allUserMembership;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembership SelectUserMembershipWithEmail(string email) {
            DataAccess.EducationOverflow.UserMembershipForEmailDataTable userMemberDataTable =
                userMembershipForEmailTableAdapter.GetData(email);

            DataObjects.UserMembership memberInfo = null;
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipForEmailRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipForEmailRow)userMemberDataTable.Rows[0];

                memberInfo = new DataObjects.UserMembership() {
                    UserId = memberInfoRow.UserId,
                    Username = memberInfoRow.Username,
                    ApplicationName = memberInfoRow.ApplicationName,
                    Email = memberInfoRow.Email,
                    IsLocked = memberInfoRow.IsLocked,
                    LastActivityDate = memberInfoRow.LastActivityDate
                };
            }

            return memberInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.UserMembership> SelectUserMembershipMatchingEmail(string email, string domain) {
            List<DataObjects.UserMembership> allUserMembership = new List<DataObjects.UserMembership>();
            DataAccess.EducationOverflow.UserMembershipMatchingEmailDataTable userMemberDataTable =
                userMembershipMatchingEmailTableAdapter.GetData(email, domain);

            foreach (DataAccess.EducationOverflow.UserMembershipMatchingEmailRow row in userMemberDataTable.Rows) {
                allUserMembership.Add(new DataObjects.UserMembership() {
                    UserId = row.UserId,
                    Username = row.Username,
                    ApplicationName = row.ApplicationName,
                    Email = row.Email,
                    IsLocked = row.IsLocked,
                    LastActivityDate = row.LastActivityDate
                });
            }

            return allUserMembership;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.UserMembership> SelectUserMembershipMatchingUsername(string username) {
            List<DataObjects.UserMembership> allUserMembership = new List<DataObjects.UserMembership>();
            DataAccess.EducationOverflow.UserMembershipMatchingUsernameDataTable userMemberDataTable =
                membershipMatchingUsernameTableAdapter.GetData(username);

            foreach (DataAccess.EducationOverflow.UserMembershipMatchingUsernameRow row in userMemberDataTable.Rows) {
                allUserMembership.Add(new DataObjects.UserMembership() {
                    UserId = row.UserId,
                    Username = row.Username,
                    ApplicationName = row.ApplicationName,
                    Email = row.Email,
                    IsLocked = row.IsLocked,
                    LastActivityDate = row.LastActivityDate
                });
            }

            return allUserMembership;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate,
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate,
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer) {
            return membershipTableAdapter.Insert(applicationName, username, password, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate,
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate,
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer, 
                long originalUserId) {
            return membershipTableAdapter.Update(applicationName, username, password, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserMembership(string applicationName, string username,
                string email, bool isLocked, DateTime lastActivityDate, 
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate, 
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer,
                long originalUserId) {
            return membershipWithoutPasswordTableAdapter.Update(applicationName, username, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserMembership(long originalUserId) {
            return membershipTableAdapter.Delete(originalUserId);
        }
    }
}
