using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Mocks
{
	public interface IContextWrapperTest
	{
		void PreSaveChanges(ContextWrapper wrapper);
	}
}
