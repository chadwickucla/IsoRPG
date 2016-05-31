using UnityEngine;
using System.Collections;


/*
Tutorials:
	Networking:	https://www.youtube.com/watch?v=JlKf0h0K5PU
		0  - 16 	basic network setup
		16 - 31	        name creation

Tips:
    all entries include ignoreclick on Load Scene Script
    closer camera in cave scenes/indoors
    longer dancing = more particles and end = fireworks	
    rotate spawnsw
    cave music
	fix up loading code
	practice scene for golems
	Gameobject: align to view
	live prefab update w/ prefab "apply"
	GC
	clicking on door sets bool to true. 
	POE health hut second floor fade in/out
	spotlight on char

Glitch:
	Spawning - individual door ID
		itemshop and patio
		duplicate scenes can work. just kinda lameo since you'll need repeats 
		for each map with multiple entrances
		maybe track location in the distance function

Assets:
	GOLEMS
	add To Town Sign/signs
	waypoint
	NPC (town)

Level:
	The Ridge style map. cliffs over the ocean. 
	Defaults outside of map to click on and move to (then stop)
	Elevated forrest walkway scene
	snowy village
	Healthhut stuff on top of cabinet
	POE Dungeon/indoor styles
	Second flood/invisi-roof		
	lower tiles in health hut
	terrain material smoothing ruins
	upstairs from health hut? Exit onto balcony ^^ no entrance on balcony though
		globals/sceneload: globals will need another int. defaults to 1. goes to
		different value if there are multiple ways out from one map to another
		
	move town entrance (from forrest) back more
	more bushes and details everywhere
	fix floatin forrest rock
	design den
	design health hut
	configure health hut player/cam prefab
	design town
	crates lower left in item shop too bright
	clipping on rocks under den
	den entrance further in if possible
	
Audio:
	Shrine/itemshop loops
	Den Music
	waterfall 3d sound
	quiter music
	footsteps
		dirt/grass
		wood
		water (add in a shallow stream in den)
NavMesh:
	thin out bridge in forrest
	tents in forrest

Mechanics:
	right click to roll
	cam: character higher in frame and cam farther max	
	spotlight
	upsidedown triangles
	healthhut shrine flame grows with monster souls
	brownout camera on load
	time passing in forrest + day counter + candles
	Waypoint
	Dumber pathfinding for player	

AI:
	chasing bool on enemies. if a nearby enemy is chasing someone, then this one chases as well (more realistic)
	- random check position after catching up to last seen spot
	- T: Line of sight and detect behind
	- Attack: Animation/Damage

Player:
	Attacking
		click enemy; chase and attack
	Health
	Animations (attack and death)

Networking:


Optimization:
	move to singleton
*/


public class _Ideas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
