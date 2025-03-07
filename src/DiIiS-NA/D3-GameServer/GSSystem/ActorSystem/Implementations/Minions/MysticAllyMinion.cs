﻿using DiIiS_NA.GameServer.MessageSystem;
using DiIiS_NA.GameServer.GSSystem.AISystem.Brains;
using DiIiS_NA.GameServer.GSSystem.PowerSystem;
using DiIiS_NA.GameServer.GSSystem.MapSystem;
using DiIiS_NA.D3_GameServer.Core.Types.SNO;

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.Minions
{
	public class MysticAllyMinion : Minion
	{
		public new int SummonLimit = 1;

		public MysticAllyMinion(World world, PowerContext context, ActorSno MysticAllyID)
			: base(world, MysticAllyID, context.User, null)
		{
			Scale = 1.35f; //they look cooler bigger :)
						   //TODO: get a proper value for this.
			WalkSpeed *= 5;
			DamageCoefficient = 5f;
			SetBrain(new MinionBrain(this));
			Attributes[GameAttributes.Summoned_By_SNO] = 0x00058676;
			(Brain as MinionBrain).AddPresetPower(169081); //melee_instant


			//Powers are activated manually now
			/*if (context.User.Attributes[GameAttribute.Rune_A, 0x00058676] > 0)
				(Brain as MinionBrain).AddPresetPower(363878); //Fire Ally -> Explosion
			if (context.User.Attributes[GameAttribute.Rune_B, 0x00058676] > 0)
				(Brain as MinionBrain).AddPresetPower(363493); //Water Ally -> Wave
			if (context.User.Attributes[GameAttribute.Rune_C, 0x00058676] > 0)
				(Brain as MinionBrain).AddPresetPower(169715); //Earth Ally -> Boulder*/

			//TODO: These values should most likely scale, but we don't know how yet, so just temporary values.
			Attributes[GameAttributes.Hitpoints_Max] = 5f * context.User.Attributes[GameAttributes.Hitpoints_Max_Total];
			Attributes[GameAttributes.Hitpoints_Cur] = Attributes[GameAttributes.Hitpoints_Max];
			Attributes[GameAttributes.Attacks_Per_Second] = context.User.Attributes[GameAttributes.Attacks_Per_Second_Total];

			Attributes[GameAttributes.Damage_Weapon_Min, 0] = 2f * context.User.Attributes[GameAttributes.Damage_Weapon_Min_Total, 0];
			Attributes[GameAttributes.Damage_Weapon_Delta, 0] = 2f * context.User.Attributes[GameAttributes.Damage_Weapon_Delta_Total, 0];

			Attributes[GameAttributes.Pet_Type] = 0x8;
			//Pet_Owner and Pet_Creator seems to be 0
		}
	}
}
