//By danny135 (BLID 16988)

exec("./Emitter.cs");

function serverCmdTeleport(%client,%p1,%p2)
{
	if(%client.isAdmin && %p1 !$= "" && %p2 !$= "")
	{
		%victim = findclientbyname(%p1);
		%target = findclientbyname(%p2);

		if(isObject(%victim) && isObject(%target))
		{
			%victim.player.setTransform(%target.player.getPosition());
			emitTeleBall(%victim);
			messageclient(%client,'',"<color:FFFF00>Teleported<color:FF0000>" SPC %victim.name SPC "<color:FFFF00>to<color:00FF00>" SPC %target.name @ "<color:FFFF00>.");
		}
		else if(!isObject(%victim.player) && !isObject(%target.player))
			messageclient(%client,'',"<color:FF0000>Players not found.");
		else if(!isObject(%victim.player))
			messageclient(%client,'',"<color:FF0000>Teleporting player not found.");
		else if(!isObject(%target.player))
			messageclient(%client,'',"<color:FF0000>Destination player not found.");
	}
	else if(!%client.isAdmin)
	{
		messageclient(%client,'',"<color:FF0000>You aren't admin.");
	}
	else if(%p2 $= "")
		messageclient(%client,'',"<color:FFFFFF>Usage: <color:FF0000>/teleport [Teleporting Player] [Destination Player]");
}