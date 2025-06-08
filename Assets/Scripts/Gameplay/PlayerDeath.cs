using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        private readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {
                // player.health.Die();
                // model.virtualCamera.Follow = null;
                // model.virtualCamera.LookAt = null;
                // // player.collider.enabled = false;
                // player.controlEnabled = false;

                // if (player.audioSource && player.ouchAudio)
                //     player.audioSource.PlayOneShot(player.ouchAudio);
                // player.animator.SetTrigger("hurt");
                // player.animator.SetBool("dead", true);
                // Simulation.Schedule<PlayerSpawn>(2);
            // }


                player.health.Decrement();
                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                if (!player.health.IsAlive)
                {
                    model.virtualCamera.Follow = null;
                    model.virtualCamera.LookAt = null;
                    // player.collider.enabled = false;
                    player.controlEnabled = false;

                    
                    player.animator.SetBool("dead", true);
                    Simulation.Schedule<PlayerSpawn>(2);
                }
                player.animator.SetTrigger("hurt");
            }
        }
    }
}