using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviModels;

namespace AviDL
{
    public interface IAviRepo
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
        File DeleteFile(File selectedFile);
        List<Pilot> GetPilots();
        Task<User> GetUserByEmail(string userEmail);
        Task<User> GetUserById(int Id);
        Task<User> AddUserAsync(User newUser);
        Task<Contributor> GetContributorById(int userId, int pilotId);
        Task<User> UpdateUserAsync(int id,User user);
        void DeleteScriptIfExists(int pilotID);
        void DeleteScenesIfExists(int pilotID);
        List<Pilot> GetPilotsByProducerID(int producerID);
    }
}