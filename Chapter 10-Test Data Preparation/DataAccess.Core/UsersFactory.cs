using AutoFixture;
using System;
using System.Linq;
using TestDataGen.Model;

namespace DataAccess.Core
{
    public class UsersFactory
    {
        private readonly UsersRepository _usersRepository;

        public UsersFactory(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void GenerateUsers(int usersCount)
        {
            var activeUsers = _usersRepository.GetAllQuery<User>().Where(x => !x.LastName.EndsWith("used") && x.Email.StartsWith("atp"));

            if (activeUsers.Count() < usersCount)
            {
                int numberOfUsersToBeGenerated = usersCount - activeUsers.Count();
                for (int i = 0; i < numberOfUsersToBeGenerated; i++)
                {
                    var fixture = new Fixture();
                    var newUser = new User()
                    {
                        Email = UniqueEmailGenerator.GenerateUniqueEmailTimestamp(),
                        FirstName = fixture.Create<string>(),
                        LastName = fixture.Create<string>(),
                        Password = fixture.Create<Guid>().ToString(),
                    };

                    _usersRepository.Insert(newUser);
                }
            }
        }

        public User GetUser()
        {
            var user = _usersRepository.GetAllQuery<User>().First(x => x.Email.StartsWith("atp"));
            user.LastName += "used";
            _usersRepository.Update(user);

            return user;
        }
    }
}
