using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using System.Transactions;

namespace Forum.Service
{
    public class DataSeedService : IDataSeedService
    {
        private IPostService _postService;
        private IMembershipService _membershipService;

        public DataSeedService(IMembershipService membershipService, IPostService postService)
        {
            if (membershipService == null)
            {
                throw new ArgumentNullException("membershipService");
            }
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            _postService = postService;
            _membershipService = membershipService;
        }

        public void SeedData()
        {
            if (SeedUsers())
            {
                SeedPosts();
            }
        }

        //seed user data
        private bool SeedUsers()
        {
            bool dataSeeded = false;
            bool userExist = _membershipService.IsUsersExist();
            if (!userExist)
            {
                
                List<User> users = new List<User>()
                {
                    new User() { Name = "System Admin", CreatedOn = DateTime.UtcNow, Email = "admin@forum.com", HashedPassword="1111", IsLocked = false, RoleId = 1 },
                    new User() { Name = "Forum Member ", CreatedOn = DateTime.UtcNow, Email = "member@forum.com", HashedPassword="1111", IsLocked = false, RoleId = 2 },
                };

                using (TransactionScope transaction = new TransactionScope())
                {
                    foreach (User user in users)
                    {
                        _membershipService.CreateUser(user);
                    }

                    transaction.Complete();
                }

                dataSeeded = true;
            }

            return dataSeeded;
        }

        //seed posts data
        private void SeedPosts()
        {
            string uml = "The pace of business is getting faster and faster, with a greater need to compete and sustain a market. In this";
            uml += " age of e−commerce, e−business, e−tailing, and other e's, (traditional) system development just doesn't cut it";
            uml += " anymore.Systems now must be developed in (Internet time.) Also, this faster pace has increased the need for";
            uml += " flexible systems. Before, a user could send a request to the data−processing center and wait two years for a";
            uml += " change.Now a user sends a request for change to the IT department and demands it in two weeks!Six−week";
            uml += " development cycles, demanding managers, demanding users, and even the concept of XP(extreme";
            uml += " programming) drive this point: System changes must happen fast! ...";

            string webApi = "The fact that you are reading this means you are interested in learning something about ASP.NET Web API (application";
            webApi += " programming interface). Perhaps you are relatively new to web services and want an expansive view.You may already";
            webApi += " be familiar with the technology and just need to swim a bit deeper into the Web API waters; hence, you need a beacon";
            webApi += " to guide you through unfamiliar places.Or maybe you are already a pro and just want to fill those few gaps in your";
            webApi += " knowledge. Wherever you are in this journey, stay tight as we are about to start our ride, and it is going to be fun! ...";

            string wcfVsApis = "After finishing his work in the Microsoft Extensibility Framework (MEF), Glenn Block joined the WCF Web API team";
            wcfVsApis += " to create success from the failure of WCF REST.Initial Community Technical Preview (CTP)versions of WCF Web API";
            wcfVsApis += " received a lot of positive feedback from the community and encouraged the team to move forward.The first preview";
            wcfVsApis += " was released in October 2010 and the latest one was version 6, which was released in November 2011...";

            string networkProtocol = "One protocol that is used for Network Management is called SNMP, which stands for";
            networkProtocol += " Simple Network Management Protocol. The SNMP protocol is an ”open” standard for the";
            networkProtocol += " Internet, which is described in an RFC.The SNMP protocol can be used for monitoring and";
            networkProtocol += " controlling many different types of equipment from different manufacturers, and not only in";
            networkProtocol += " TCP / IP networks....";

            string security = "In our first chapter, we enter the domain of Security Management. Throughout";
            security += " this book, you will see that many Information Systems Security (InfoSec)";
            security += " domains have several elements and concepts that overlap.While all other";
            security += " security domains are clearly focused, this domain, for example, introduces";
            security += " concepts that we extensively touch upon in both the Operations Security";
            security += " (Chapter 6, Operations Security) and Physical Security(Chapter 10, Physical";
            security += " Security) domains.We will try to point out those occasions where the";
            security += " material is repetitive, but be aware that if we describe a concept in several";
            security += " domains, you need to understand it....";

            string softwareArchitect = "A simplistic view of the role is that architects create architectures, and their responsibilities encompass all that is involved in doing so. This would include";
            softwareArchitect += " articulating the architectural vision, conceptualizing and experimenting with alternative architectural approaches, creating models and component and";
            softwareArchitect += " interface specification documents, and validating the architecture against requirements and assumptions.However, any experienced architect knows";
            softwareArchitect += " that the role involves not just these technical activities, but others that are more political and strategic in nature on the one hand, and more like those of a";
            softwareArchitect += " consultant, on the other....";

            List<Post> posts = new List<Post>()
                {
                    new Post() { UserId = 1, CategoryId = 1, DatePosted = DateTime.UtcNow, Subject = "Introduction to UML", Body = uml },
                    new Post() { UserId = 1, CategoryId = 1, DatePosted = DateTime.UtcNow, Subject = "Introduction to Web API", Body = webApi },
                    new Post() { UserId = 1, CategoryId = 1, DatePosted = DateTime.UtcNow, Subject = "WCF Web APIs", Body = wcfVsApis },
                    new Post() { UserId = 1, CategoryId = 2, DatePosted = DateTime.UtcNow, Subject = "Simple Network Management Protocol", Body = networkProtocol },
                    new Post() { UserId = 1, CategoryId = 3, DatePosted = DateTime.UtcNow, Subject = "Security Management Practices", Body = security },
                    new Post() { UserId = 1, CategoryId = 1, DatePosted = DateTime.UtcNow, Subject = "The Role of the Architect", Body = softwareArchitect },
                };

            using (TransactionScope transaction = new TransactionScope())
            {
                foreach (Post post in posts)
                {
                    _postService.Create(post);
                }

                transaction.Complete();
            }
        }
    }








}




