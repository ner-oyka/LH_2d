using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Player")]
    public class NC_SwitchPlayerComponents : ActionTask<Transform>
    {
        public BBParameter<bool> Movement;
        public BBParameter<bool> Rotate;
        public BBParameter<bool> Jerk;
        public BBParameter<bool> Interaction;

        Game.Player.PlayerMovement playerMovement;
        Game.Player.PlayerRotate playerRotate;
        Game.Player.PlayerJerk playerJerk;
        Game.Player.PlayerInteraction playerInteraction;

        protected override string OnInit()
        {
            playerMovement = agent.GetComponent<Game.Player.PlayerMovement>();
            playerRotate = agent.GetComponent<Game.Player.PlayerRotate>();
            playerJerk = agent.GetComponent<Game.Player.PlayerJerk>();
            playerInteraction = agent.GetComponent<Game.Player.PlayerInteraction>();
            return null;
        }

        protected override void OnExecute()
        {
            playerMovement.enabled = Movement.value;
            playerRotate.enabled = Rotate.value;
            playerJerk.enabled = Jerk.value;
            playerInteraction.enabled = Interaction.value;
            EndAction(true);
        }
    }

}