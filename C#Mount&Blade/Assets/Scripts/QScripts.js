#pragma strict

//Quick scripts for things not inherent in Unity

function getIndex(toGet,arrayIn : Array)
{
	for(var i=0;i<arrayIn.length;i++)
	{
		if(toGet == arrayIn[i])
		{
			return i;
		}
	}
	return -1;
}