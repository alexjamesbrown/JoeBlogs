using System;
using CookComputing.XmlRpc;

namespace JoeBlogs
{
	/// <summary> 
	/// This struct represents information about a user. 
	/// </summary> 
	[XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct XmlRpcData
	{
		public string name;
		public string type;
		public string base64;
		public bool overwrite;
	}
}