using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoCoding.Repository;

namespace GeoCoding.Model
{
    public interface IJoinedProspectService
    {
        IEnumerable<JoinedProspect> getList();
    }

    public abstract class JoinedProspectServiceBase : IJoinedProspectService
    {
        public abstract IEnumerable<JoinedProspect> getList();
    }

    public class JoinedProspectService : JoinedProspectServiceBase
    {
        JoinedProspectRepository joinedProspectRepository = new JoinedProspectRepository();

        public override IEnumerable<JoinedProspect> getList()
        {
            return joinedProspectRepository.GetList();
        }


    }

}