using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using Forum.Domain.Models;
using System.Security.Principal;
using System.Web.Security;

namespace Forum.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Person> _userRepository;
        private readonly ICryptoService _cryptoService;

        public MembershipService(IRepository<Person> userRepository, IRepository<Role> roleRepository, ICryptoService cryptoService)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }
            if (roleRepository == null)
            {
                throw new ArgumentNullException("roleRepository");
            }
            if (cryptoService == null)
            {
                throw new ArgumentNullException("cryptoService");
            }

            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _cryptoService = cryptoService;
        }

        public Person GetUserById(int id)
        {
            try
            {
                return _userRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Person> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Person GetUserByEmail(string email)
        {
            try
            {
                return _userRepository.GetSingleBy(u => u.Email == email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person CreateUser(Person user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }

                if (UserExist(user.Email))
                {
                    throw new Exception("User already exist!");
                }

                //get default role
                //Role defaultRole = _roleRepository.GetSingleBy(r => r.Name == "User");

                Role defaultRole = new Role() { Id = 2 };
                if (defaultRole == null)
                {
                    throw new Exception("Default role does not exist! Please contact you system administrator");
                }

                //user.Id = Guid.NewGuid();
                user.Salt = _cryptoService.GenerateSalt();
                user.HashedPassword = _cryptoService.EncryptPassword(user.HashedPassword, user.Salt);
                user.RoleId = defaultRole.Id;
                user.CreatedOn = DateTime.Now;
                user.IsLocked = false;

                _userRepository.Add(user);
                _userRepository.Save();

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UserExist(string email)
        {
            try
            {
                Person user = GetUserByEmail(email);
                return user != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PersonContext ValidateUser(string email, string password)
        {
            try
            {
                PersonContext userContext = null;
                Person user = _userRepository.GetSingleBy(u => u.Email == email, "Role");

                if (user != null && IsUserValid(user, password))
                {
                    userContext = new PersonContext();
                    string[] roles = new string[] { user.Role.Name };
                    GenericIdentity identity = new GenericIdentity(user.Name);

                    userContext.User = user;
                    userContext.Principal = new GenericPrincipal(identity, roles);
                }

                return userContext;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        private bool IsUserValid(Person existingUser, string password)
        {
            try
            {
                if (existingUser == null)
                {
                    throw new ArgumentNullException("existingUser");
                }

                if (IsPasswordValid(existingUser, password))
                {
                    return !existingUser.IsLocked;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsPasswordValid(Person existingUser, string password)
        {
            try
            {
                if (existingUser == null)
                {
                    throw new ArgumentNullException("existingUser");
                }

                string enteredPassword = _cryptoService.EncryptPassword(password, existingUser.Salt);
                return string.Equals(enteredPassword, existingUser.HashedPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }











    //public class MembershipService : MembershipProvider
    //{
    //    //private readonly IRepository<Role> _roleRepository;
    //    private readonly IRepository<Person> _userRepository;
    //    private readonly ICryptoService _cryptoService;

    //    public MembershipService(IRepository<Person> userRepository, ICryptoService cryptoService)
    //    {
    //        if (userRepository == null)
    //        {
    //            throw new ArgumentNullException("userRepository");
    //        }

    //        if (cryptoService == null)
    //        {
    //            throw new ArgumentNullException("cryptoService");
    //        }

    //        _userRepository = userRepository;
    //        _cryptoService = cryptoService;
    //    }

    //    public override string ApplicationName
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //        set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool EnablePasswordReset
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override bool EnablePasswordRetrieval
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override int GetNumberOfUsersOnline()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string GetPassword(string username, string answer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override MembershipUser GetUser(string username, bool userIsOnline)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string GetUserNameByEmail(string email)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override int MaxInvalidPasswordAttempts
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override int MinRequiredNonAlphanumericCharacters
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override int MinRequiredPasswordLength
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override int PasswordAttemptWindow
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override MembershipPasswordFormat PasswordFormat
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string PasswordStrengthRegularExpression
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override bool RequiresQuestionAndAnswer
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override bool RequiresUniqueEmail
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string ResetPassword(string username, string answer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool UnlockUser(string userName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void UpdateUser(MembershipUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool ValidateUser(string username, string password)
    //    {
    //        try
    //        {
    //            Person user = _userRepository.GetSingleBy(u => u.Email == username, "Role");
    //            if (user != null && IsUserValid(user, password))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    private bool IsUserValid(Person existingUser, string password)
    //    {
    //        try
    //        {
    //            if (existingUser == null)
    //            {
    //                throw new ArgumentNullException("existingUser");
    //            }

    //            if (IsPasswordValid(existingUser, password))
    //            {
    //                return !existingUser.IsLocked;
    //            }

    //            return false;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    private bool IsPasswordValid(Person existingUser, string password)
    //    {
    //        try
    //        {
    //            if (existingUser == null)
    //            {
    //                throw new ArgumentNullException("existingUser");
    //            }

    //            string enteredPassword = _cryptoService.EncryptPassword(password, existingUser.Salt);
    //            return string.Equals(enteredPassword, existingUser.HashedPassword);
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }




    //}










}
