using System.Configuration;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using Petabridge.Cmd.Host;

namespace PetabridgeCmdIssue34Reproduction
{
  internal class Program
  {
    public static async Task Main(string[] args)
    {
        var section = (AkkaConfigurationSection)ConfigurationManager.GetSection("akka");
        var actorSys = ActorSystem.Create("MyActorSystem", section.AkkaConfig);

        PetabridgeCmd.Get(actorSys).Start();

        await actorSys.WhenTerminated;
    }
  }
}