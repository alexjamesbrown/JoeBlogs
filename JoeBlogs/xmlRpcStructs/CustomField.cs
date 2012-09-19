﻿using System;
using CookComputing.XmlRpc;

namespace JoeBlogs
{
	/// <summary>
	/// Custom field info attached to a blog item.
	/// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct XmlRpcCustomField
	{
		public string id;
		public string key;
		public string value;

	}
}
