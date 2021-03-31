using AviModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AviDL;

namespace AviBL
{
    public class AviatorBL : IAviBL
    {
        private IAviRepo _repo;

        public AviatorBL(IAviRepo repo)
        {
            _repo = repo;
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            User user2Return = await _repo.GetUserByEmail(userEmail);

            if (user2Return == null)
            {
                user2Return = new User();
                user2Return.Email = userEmail;
                return await _repo.AddUserAsync(user2Return);
            }
            else
            {
                return user2Return;
            }
        }
        public async Task<User> AddUser(User userdetail)
        {
            User user = new User();
            user.FirstName = userdetail.FirstName;
            user.LastName = userdetail.LastName;
            user.PhoneNumb = userdetail.PhoneNumb;
            user.UserName = userdetail.UserName;
            user.Email = userdetail.Email;
            return await _repo.AddUserAsync(user);
        }
        public async Task<User> UpdateUser(int id,User user)
        {
            return await _repo.UpdateUserAsync(id,user);
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _repo.GetUserById(userId);
        }
        public async Task<Contributor> GetContributorById(int userId, int pilotId)
        {
            return await _repo.GetContributorById(userId, pilotId);
        }
        public Contributor AddContributor(Contributor newContributor)
        {
            return _repo.AddContributor(newContributor);
        }

        public File AddFile(File newFile)
        {
            return _repo.AddFile(newFile);
        }

        public Pilot AddPilot(Pilot newPilot)
        {
            return _repo.AddPilot(newPilot);
        }

        public Scene AddScene(Scene newScene)
        {
            return _repo.AddScene(newScene);
        }

        public SceneFile AddSceneFile(SceneFile newSF)
        {
            return _repo.AddSceneFile(newSF);
        }

        public Script AddScript(Script newScript)
        {
            return _repo.AddScript(newScript);
        }

        public File DeleteFile(File selectedFile)
        {
            return _repo.DeleteFile(selectedFile);
        }

        public List<Contributor> GetContributorsByUserID(int userID)
        {
            return _repo.GetContributorsByUserID(userID);
        }

        public List<Contributor> GetContributorsByPilotID(int pilotID)
        {
            return _repo.GetContributorsByPilotID(pilotID);
        }

        public List<File> GetFilesByPilotID(int pilotID)
        {
            return _repo.GetFilesByPilotID(pilotID);
        }

        public List<File> GetFilesBySceneId(int sfID)
        {
            return _repo.GetFilesBySceneId(sfID);
        }

        public Pilot GetPilotByID(int id)
        {
            return _repo.GetPilotByID(id);
        }

        public List<Scene> GetScenesByPilotID(int pilotID)
        {
            return _repo.GetScenesByPilotID(pilotID);
        }

        public Script GetScriptByPilotID(int pilotID)
        {
            return _repo.GetScriptByPilotID(pilotID);
        }

        public List<Pilot> GetPilots()
        {
            return _repo.GetPilots();
        }

        public void DeleteScriptIfExists(int pilotID)
        {
            _repo.DeleteScriptIfExists(pilotID);
        }

        public void DeleteScenesIfExists(int pilotID)
        {
            _repo.DeleteScenesIfExists(pilotID);
        }

        public List<Pilot> GetPilotsByProducerID(int producerID)
        {
            return _repo.GetPilotsByProducerID(producerID);
        }
    }
}
