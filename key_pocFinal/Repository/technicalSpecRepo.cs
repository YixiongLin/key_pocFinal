using key_pocFinal.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace key_pocFinal.Repository
{
    public class technicalSpecRepo : genericRepo<tblTechnicalSpec>
    {
        public technicalSpecRepo(KEY_TeamMVCEntities db)
            : base(db) { }

        public double getTSPropertyValue(int id, string property)
        {
            if (property == "AirFlow")
            {
                if (get(id).AirFlow != null)
                {
                    return (double)get(id).AirFlow;
                }
            }
            if (property == "MinPow")
            {
                if (get(id).MinPow != null)
                {
                    return (double)get(id).MinPow;
                }
            }
            if (property == "MaxPow")
            {
                if (get(id).MaxPow != null)
                {
                    return (double)get(id).MaxPow;
                }
            }
            if (property == "MinOV")
            {
                if (get(id).MinOV != null)
                {
                    return (double)get(id).MinOV;
                }
            }
            if (property == "MaxOV")
            {
                if (get(id).MaxOV != null)
                {
                    return (double)get(id).MaxOV;
                }
            }
            if (property == "MinRPM")
            {
                if (get(id).MinRPM != null)
                {
                    return (double)get(id).MinRPM;
                }
            }
            if (property == "MaxRPM")
            {
                if (get(id).MaxRPM != null)
                {
                    return (double)get(id).MaxRPM;
                }
            }
            if (property == "NumberFanSpeed")
            {
                if (get(id).NumberFanSpeed != null)
                {
                    return (double)get(id).NumberFanSpeed;
                }
            }
            if (property == "dB")
            {
                if (get(id).dB != null)
                {
                    return (double)get(id).dB;
                }
            }
            if (property == "FanSweepDiameter")
            {
                if (get(id).FanSweepDiameter != null)
                {
                    return (double)get(id).FanSweepDiameter;
                }
            }
            if (property == "MinHeight")
            {
                if (get(id).MinHeight != null)
                {
                    return (double)get(id).MinHeight;
                }
            }
            if (property == "MaxHeight")
            {
                if (get(id).MaxHeight != null)
                {
                    return (double)get(id).MaxHeight;
                }
            }
            if (property == "Weight")
            {
                if (get(id).Weight != null)
                {
                    return (double)get(id).Weight;
                }
            }
            return 0;
        }

        public KEY_TeamMVCEntities KEY_TeamMVCEntities
        {
            get { return _dbContext as KEY_TeamMVCEntities; }
        }
    }
}