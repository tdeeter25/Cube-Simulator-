#pragma strict
var rend=GetComponent.<Renderer>();

function OnMouseEnter()
{

	rend.material.color = Color.black;
}


function OnMouseExit()
{
	rend.material.color = Color.white;
}

function OnMouseDown()
{
	Application.LoadLevel(2);
	}
	

