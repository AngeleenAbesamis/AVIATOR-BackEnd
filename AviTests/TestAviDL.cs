using AviDL;
using AviModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviTests
{
    public class TestAviDL
    {
        private readonly DbContextOptions<AviDBContext> options;
        public TestAviDL()
        {
            options = new DbContextOptionsBuilder<AviDBContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
        }
        [Fact]
        public async Task AddContributorShouldAddContributor()
        {
            Contributor c = new Contributor { PilotID = 1, UserID = 1 };
            using (var ctx = new AviDBContext(options))
            {
                List<User> users = ctx.Users.ToList();
                List<Pilot> pilots = ctx.Pilots.ToList();
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddContributor(c);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.Contributors.FirstOrDefault(_c => _c.ID == c.ID);
                Assert.NotNull(result);
                Assert.Equal(1, result.PilotID);
                Assert.Equal(1, result.UserID);
            }
        }
        [Fact]
        public async Task AddFileShouldAddFile()
        {
            File f = new File { PilotID = 1, UploaderID = 1, FileURL = "https://www.google.com/" };
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddFile(f);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.Files.FirstOrDefault(_f => _f.ID == f.ID);
                Assert.NotNull(result);
                Assert.Equal(1, result.PilotID);
                Assert.Equal(1, result.UploaderID);
                Assert.Equal("https://www.google.com/", result.FileURL);
            }
        }
        [Fact]
        public async Task AddPilotShouldAddPilot()
        {
            Pilot p = new Pilot { ProducerID = 4 };
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddPilot(p);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.Pilots.FirstOrDefault(_p => _p.ID == p.ID);
                Assert.NotNull(result);
                Assert.Equal(4, p.ProducerID);
            }
        }
        [Fact]
        public async Task AddSceneShouldAddScene()
        {
            Scene s = new Scene { SceneIndex = 1, PilotID = 1 };
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddScene(s);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.Scenes.FirstOrDefault(_s => _s.ID == s.ID);
                Assert.NotNull(result);
                Assert.Equal(1, result.SceneIndex);
                Assert.Equal(1, result.PilotID);
            }
        }
        [Fact]
        public async Task AddSceneFileShouldAddSceneFile()
        {
            SceneFile sf = new SceneFile { SceneID = 1, FileID = 1 };
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddSceneFile(sf);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.SceneFiles.FirstOrDefault(_sf => _sf.ID == sf.ID);
                Assert.NotNull(result);
                Assert.Equal(1, result.SceneID);
                Assert.Equal(1, result.FileID);
            }
        }
        [Fact]
        public async Task AddScriptShouldAddScript()
        {
            Pilot p = new Pilot { ProducerID = 4 };
            Script s = new Script { ScriptWriterID = 5 };
            using (var ctx = new AviDBContext(options))
            {
                ctx.Pilots.Add(p);
                ctx.SaveChanges();
                s.PilotID = p.ID;
                IAviRepo repo = new AviRepoDB(ctx);
                repo.AddScript(s);
            }
            using (var assertCtx = new AviDBContext(options))
            {
                var result = assertCtx.Scripts.FirstOrDefault(_s => _s.ID == s.ID);
                Assert.NotNull(result);
                Assert.Equal(5, result.ScriptWriterID);
                Assert.Equal(p.ID, result.PilotID);
            }
        }
        [Fact]
        public async Task DeleteFileShouldDeleteFile()
        {
            using (var ctx = new AviDBContext(options))
            {
                File file = ctx.Files.FirstOrDefault(f => true);
                Assert.NotNull(file);
                int fID = file.ID;
                IAviRepo repo = new AviRepoDB(ctx);
                repo.DeleteFile(file);
                file = ctx.Files.FirstOrDefault(f => f.ID == fID);
                Assert.Null(file);
            }
        }
        [Fact]
        public async Task GetContributorsByUserIDShouldGetContributors()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<Contributor> contributors = repo.GetContributorsByUserID(2);
                Assert.NotNull(contributors);
                Assert.NotEmpty(contributors);
            }
        }
        [Fact]
        public async Task GetContributorsByPilotIDShouldGetContributors()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<Contributor> contributors = repo.GetContributorsByPilotID(1);
                Assert.NotNull(contributors);
                Assert.NotEmpty(contributors);
            }
        }
        [Fact]
        public async Task GetFilesByPilotIDShouldGetFiles()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<File> files = repo.GetFilesByPilotID(1);
                Assert.NotNull(files);
                Assert.NotEmpty(files);
            }
        }
        [Fact]
        public async Task GetFilesBySceneIdShouldGetFiles()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<File> files = repo.GetFilesBySceneId(1);
                Assert.NotNull(files);
                Assert.NotEmpty(files);
            }
        }
        [Fact]
        public async Task GetPilotByIDShouldGetPilot()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                Pilot p = repo.GetPilotByID(1);
                Assert.NotNull(p);
                Assert.Equal(1, p.ID);
            }
        }
        [Fact]
        public async Task GetScenesByPilotIDShouldGetScenes()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<Scene> scenes = repo.GetScenesByPilotID(1);
                Assert.NotNull(scenes);
                Assert.NotEmpty(scenes);
            }
        }
        [Fact]
        public async Task GetScriptsByPilotIDShouldGetScripts()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                Script script = repo.GetScriptByPilotID(1);
                Assert.NotNull(script);
                Assert.Equal(1, script.PilotID);
            }
        }
        [Fact]
        public async Task GetPilotsShouldGetPilots()
        {
            using (var ctx = new AviDBContext(options))
            {
                IAviRepo repo = new AviRepoDB(ctx);
                List<Pilot> pilots = repo.GetPilots();
                Assert.NotNull(pilots);
                Assert.NotEmpty(pilots);
            }
        }
        private async Task Seed()
        {
            using (var ctx = new AviDBContext(options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                for (int i = 1; i <= 5; i++)
                {
                    ctx.Users.Add(new User { Email = $"user{i}@gmail.com", FirstName = $"FN{i}", LastName = $"LN{i}", PhoneNumb = i * 1111111111, UserName = $"User{i}" });
                }
                ctx.SaveChanges();
                List<Scene> scenes = new List<Scene>();
                scenes.Add(new Scene { SceneIndex = 0 });
                ctx.Pilots.Add(new Pilot { ProducerID = 1, Script = new Script { ScriptURL = "https://www.script.com/", ScriptWriterID = 2 }, Scenes = scenes });
                ctx.SaveChanges();
                ctx.Contributors.Add(new Contributor { PilotID = 1, UserID = 2 });
                ctx.Contributors.Add(new Contributor { PilotID = 1, UserID = 3 });
                ctx.Files.Add(new File { FileURL = "https://www.file.com", PilotID = 1, UploaderID = 3 });
                ctx.SceneFiles.Add(new SceneFile { SceneID = 1, FileID = 1 });
                ctx.SaveChanges();
            }
        }
    }
}
