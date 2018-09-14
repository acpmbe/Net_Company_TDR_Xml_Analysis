using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Other.ChuZuWu
{
	public class Class1
	{

		public bool IsOpen { get; set; }

		public List<TokenInfo> TokenLit { get; set; }
		public List<AppKeyInfo> AppKeyList { get; set; }

		public class TokenInfo
		{
			public string Type { get; set; }
			public string Token { get; set; }
		}

		public class AppKeyInfo
		{
			public string AppKey { get; set; }
			public string MasterSecret { get; set; }
		}
	}
}
