using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviModels;

namespace AviBL
{
    public interface IAviBL
    {
        Pilot AddPilot(Pilot newPilot);
        Scene AddScene(Scene newScene);
        File AddFile(File newFile);
        SceneFile AddSceneFile(SceneFile newSF);
        Contributor AddContributor(Contributor newContributor);
        Script AddScript(Script newScript);
        Script GetScriptByPilotID(int pilotID);
        Pilot GetPilotByID(int id);
        List<Scene> GetScenesByPilotID(int pilotID);
        List<File> GetFilesByPilotID(int pilotID);
        List<File> GetFilesBySceneId(int sfID);
        List<Contributor> GetContributorsByPilotID(int pilotID);
        List<Contributor> GetContributorsByUserID(int userID);
        List<Pilot> GetPilots();
        File DeleteFile(File selectedFile);
        Task<User> GetUserByEmail(string userEmail);
        Task<User> GetUserById(int Id);
        Task<Contributor> GetContributorById(int userId, int pilotId);
        Task<User> AddUser(User userdetail);
        Task<User> UpdateUser(int id,User user);
        void DeleteScriptIfExists(int pilotID);
        void DeleteScenesIfExists(int pilotID);
        List<Pilot> GetPilotsByProducerID(int producerID);
    }
}
