using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoCoding.Repository;

namespace GeoCoding.Model
{
    public class JoinedProspectService
    {
        JoinedProspectRepository joinedProspectRepository = new JoinedProspectRepository();

        public List<JoinedProspect> getList()
        {
            return joinedProspectRepository.GetList();
        }   
    
    
    }
}
