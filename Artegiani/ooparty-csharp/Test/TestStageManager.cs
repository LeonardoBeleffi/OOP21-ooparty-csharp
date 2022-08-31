using Application.StageManager;
using NUnit.Framework;
using ooparty_csharp.SceneHandler;

namespace ooparty_csharp
{
    /// <summary>
    /// Test class for the stage manager.
    /// </summary>
    [TestFixture]
    public class TestStageManager
    {
        [Test]
        public void TestAddScene()
        {
            IStageManager<string> s = new StageManager<string>(new SceneHandler<string>());
            s.AddScene(null);
            Assert.IsTrue(s.Scenes.Count == 0);
            s.AddScene("1");
            s.AddScene("2");
            Assert.IsFalse(s.Scenes.Count == 0);
            s.AddScene("3");
            Assert.AreEqual(3, s.Scenes.Count);
        }

        [Test]
        public void TestPopScene()
        {
            IStageManager<string> s = new StageManager<string>(new SceneHandler<string>());
            s.AddScene("1");
            s.AddScene("2");
            s.AddScene("3");
            Assert.AreEqual("3", s.PopScene());
            Assert.AreEqual("2", s.PopScene());
            Assert.AreEqual("1", s.PopScene());
            Assert.IsTrue(s.Scenes.Count == 0);
        }
    }
}
