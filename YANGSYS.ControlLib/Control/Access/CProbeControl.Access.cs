using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Component;
using SOFD.Component.Interface;

namespace YANGSYS.ControlLib
{
    /// <summary>
    /// CProbeControl의 요약
    /// </summary>
    public partial class CProbeControl
    {
        private CControlAttribute @__OB_RUNNING
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RUNNING")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_CIM_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_CIM_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_AUTO_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_AUTO_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_AUTO_RECIPE_CHANGE_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_AUTO_RECIPE_CHANGE_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_STATUS_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_STATUS_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_CIM_MODE_CHANGE_COMMAND_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_CIM_MODE_CHANGE_COMMAND_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_TIME_SET_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_TIME_SET_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LIGHT_ALARM_OCCURRED
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LIGHT_ALARM_OCCURRED")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LIGHT_ALARM_CLEARED
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LIGHT_ALARM_CLEARED")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_SERIOUS_ALARM_OCCURRED
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_SERIOUS_ALARM_OCCURRED")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_SERIOUS_ALARM_CLEARED
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_SERIOUS_ALARM_CLEARED")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_SCRAP_JOB_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_SCRAP_JOB_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_STORED_JOB_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_STORED_JOB_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_FETCHED_OUT_JOB_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_FETCHED_OUT_JOB_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_DATA_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_DATA_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_PROCESS_START_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_PROCESS_START_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_PROCESS_END_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_PROCESS_END_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_DV_DATA_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_DV_DATA_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_RECIPE_LIST_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RECIPE_LIST_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_RECIPE_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_RECIPE_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_RECIPE_PARAMETER_DATA_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RECIPE_PARAMETER_DATA_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_RECIPE_PARAMETER_DATA_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RECIPE_PARAMETER_DATA_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_RECIPE_PARMATER_DOWN_CONFIRM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_RECIPE_PARMATER_DOWN_CONFIRM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_CIM_MESSAGE_CONFIRM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_CIM_MESSAGE_CONFIRM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_PANEL_DATA_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_PANEL_DATA_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_PANEL_DATA_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_PANEL_DATA_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_JUDGE_RESULT_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_JUDGE_RESULT_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_JUDGE_RESULT_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_JUDGE_RESULT_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_GLASS_DATA_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_GLASS_DATA_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_IONIZER_STATUS_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_IONIZER_STATUS_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_MODE_CHANGE_COMMAND_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_MODE_CHANGE_COMMAND_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_MACHINE_MODE_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_MACHINE_MODE_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SENT_OUT_JOB_DATA_SUB_BLOCK1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SENT_OUT_JOB_DATA_SUB_BLOCK1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_JOB_DATA_FOR_UPSTREAM_BLOCK1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_JOB_DATA_FOR_UPSTREAM_BLOCK1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_RECEIVED_JOB_DATA_SUB_BLOCK1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_RECEIVED_JOB_DATA_SUB_BLOCK1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SCRAP_DATA_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SCRAP_DATA_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SCRAP_DATA_SCRAP_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SCRAP_DATA_SCRAP_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SCRAP_DATA_UNIT_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SCRAP_DATA_UNIT_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SCRAP_DATA_OPERATORID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SCRAP_DATA_OPERATORID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_BLOCK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_BLOCK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_UNIT_OR_PORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_UNIT_OR_PORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_SUB_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_SUB_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_PORT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_PORT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_STORED_DATA_SLOT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_STORED_DATA_SLOT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_DATA_JOB_DATA_BLOCK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_DATA_JOB_DATA_BLOCK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_SUB_DATA_UNIT_OR_PORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_SUB_DATA_UNIT_OR_PORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_SUB_DATA_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_SUB_DATA_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_SUB_DATA_SUB_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_SUB_DATA_SUB_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_SUB_DATA_PORT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_SUB_DATA_PORT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_FETCHED_OUT_SUB_DATA_SLOT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_FETCHED_OUT_SUB_DATA_SLOT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLASS_DATA_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLASS_DATA_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_PROCESS_START_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_PROCESS_START_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_PROCESS_START_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_PROCESS_START_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_PROCESS_END_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_PROCESS_END_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_PROCESS_END_UNIT_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_PROCESS_END_UNIT_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_STATUS
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_STATUS")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_REASON_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_REASON_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_DOWN_ALARM_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_DOWN_ALARM_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_UNIT1_STATUS
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_UNIT1_STATUS")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_GLASS_COUNT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_GLASS_COUNT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_POSITION_GLASS_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_POSITION_GLASS_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_POSITION001_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_POSITION001_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_POSITION002_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_POSITION002_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_CIM_MESSAGE_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_CIM_MESSAGE_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_TOUCH_PANLE_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_TOUCH_PANLE_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_CIM_MODE_CHANGE_RETURN_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_CIM_MODE_CHANGE_RETURN_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_LIGHT_ALAM_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_LIGHT_ALAM_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SERIOUS_ALARM_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SERIOUS_ALARM_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_RECIPE_PARAMETER_DOWN_RESULT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_RECIPE_PARAMETER_DOWN_RESULT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_RECIPE_REQUEST_PPID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_RECIPE_REQUEST_PPID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_RECIPE_REQUEST_UNIT_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_RECIPE_REQUEST_UNIT_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_RECIPE_LIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_RECIPE_LIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_PROCESSING_PPID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_PROCESSING_PPID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_PROCESSING_MACHINE_RECIPE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_PROCESSING_MACHINE_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_REQ_OPTION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_REQ_OPTION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_REQ_GLASS_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_REQ_GLASS_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_REQ_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_REQ_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_REQ_GLASS_JUDGE_RESULT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_REQ_GLASS_JUDGE_RESULT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_RRT_OPTION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_RRT_OPTION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_RRT_GLASS_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_RRT_GLASS_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_RRT_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_RRT_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_JUDGE_RRT_GLASS_JUDGE_RESULT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_JUDGE_RRT_GLASS_JUDGE_RESULT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_DATA_REQ_OPTION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_DATA_REQ_OPTION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_DATA_REQ_GLASS_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_DATA_REQ_GLASS_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_GLS_DATA_REQ_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_GLS_DATA_REQ_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_IONIZER_STATUS
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_IONIZER_STATUS")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_MODE_CHANGE_RETURN_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_MODE_CHANGE_RETURN_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_MACHINE_RECIPE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_MACHINE_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_RECIPE_PARAMETER_DATA
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_RECIPE_PARAMETER_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_CV_DATA
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_CV_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_SV_DATA
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_SV_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_GLASS_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_GLASS_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_PROCESSING_IN_UNIT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_PROCESSING_IN_UNIT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME1_HOUR
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME1_HOUR")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME1_MIN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME1_MIN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME1_SEC
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME1_SEC")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME1_MILSEC
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME1_MILSEC")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME2_HOUR
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME2_HOUR")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME2_MIN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME2_MIN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME2_SEC
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME2_SEC")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_TOTAL_PROCESS_TIME2_MILSEC
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_TOTAL_PROCESS_TIME2_MILSEC")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OW_DV_DATA
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OW_DV_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_SCRAP_JOB_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_SCRAP_JOB_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_STORED_JOB_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_STORED_JOB_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_FETCHED_OUT_JOB_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_FETCHED_OUT_JOB_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_DATA_CHANGE_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_DATA_CHANGE_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_PROCESS_START_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_PROCESS_START_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_PROCESS_END_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_PROCESS_END_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_MACHINE_RECIPE_REQUEST_CONFIRM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_MACHINE_RECIPE_REQUEST_CONFIRM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_MACHINE_STATUS_CHANGE_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_MACHINE_STATUS_CHANGE_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_RECIPE_PARAMETER_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_RECIPE_PARAMETER_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_RECIPE_PARAMETER_DOWNLOAD
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_RECIPE_PARAMETER_DOWNLOAD")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_CIM_MESSAGE_SET_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_CIM_MESSAGE_SET_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_CIM_MESSAGE_CLEAR_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_CIM_MESSAGE_CLEAR_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_MACHINE_TIME_SET_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_MACHINE_TIME_SET_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_CIM_MODE_CHANGE_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_CIM_MODE_CHANGE_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_CV_REPORT_TIME_CHANGE_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_CV_REPORT_TIME_CHANGE_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_JUDGE_RESULT_REPORT_REPLY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_JUDGE_RESULT_REPORT_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_GLASS_DATA_REQUEST_CONFIRM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_GLASS_DATA_REQUEST_CONFIRM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_MACHINE_MODE_CHANGE_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_MACHINE_MODE_CHANGE_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LOADING_STOP_REQUEST_REPLY_CIM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LOADING_STOP_REQUEST_REPLY_CIM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LOADING_STOP_RELEASE_REPLY_CIM
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LOADING_STOP_RELEASE_REPLY_CIM")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CV_REPORT_ENABLE_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CV_REPORT_ENABLE_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CV_REPORT_TIME
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CV_REPORT_TIME")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MESSAGE_SET_MESSAGE_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MESSAGE_SET_MESSAGE_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MESSAGE_SET_TOUCH_PANEL_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MESSAGE_SET_TOUCH_PANEL_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MESSAGE_SET_MSG_DATA
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MESSAGE_SET_MSG_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MESSAGE_CLEAR_MESSAGE_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MESSAGE_CLEAR_MESSAGE_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MESSAGE_CLEAR_TOUCH_PANEL_NO
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MESSAGE_CLEAR_TOUCH_PANEL_NO")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_CIM_MODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_CIM_MODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_YEAR
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_YEAR")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_MONTH
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_MONTH")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_DAY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_DAY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_HOUR
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_HOUR")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_MINUTE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_MINUTE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_TIME_SEND_SECOND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_TIME_SEND_SECOND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_RECIPE_PARAMETER_REQUEST_UNIT_ID
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_RECIPE_PARAMETER_REQUEST_UNIT_ID")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_SEND_GLASS_JUDGE_RESULT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_SEND_GLASS_JUDGE_RESULT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_GLASS_DATA_SEND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_GLASS_DATA_SEND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_GLASS_DATA_REQUEST_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_GLASS_DATA_REQUEST_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_MODE_CHANGE_COMMAND
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_MODE_CHANGE_COMMAND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_LOADING_STOP_REQUEST_RETURN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_LOADING_STOP_REQUEST_RETURN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_LOADING_STOP_RELEASE_RETURN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_LOADING_STOP_RELEASE_RETURN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_MACHINE_RECIPE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_MACHINE_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IW_RECIPE_PARAMETER_DATA_DOWNLOAD
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IW_RECIPE_PARAMETER_DATA_DOWNLOAD")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }




        private CControlAttribute @__OB_LINK_UP_UPSTREAM_INLINE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_UPSTREAM_INLINE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_UPSTREAM_TROUBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_UPSTREAM_TROUBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_NUMBER1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_NUMBER1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_NUMBER2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_NUMBER2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_NUMBER3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_NUMBER3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_NUMBER4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_NUMBER4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_NUMBER5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_NUMBER5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_ARM_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_ARM_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_JOB_TRANSFER_SIGNAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_JOB_TRANSFER_SIGNAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SEND_ABLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SEND_ABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SEND_START
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SEND_START")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SEND_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SEND_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_EXCHANGE_POSSIBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_EXCHANGE_POSSIBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_EXCHANGE_EXECUTE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_EXCHANGE_EXECUTE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_RESUME_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_RESUME_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_RESUME_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_RESUME_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CANCEL_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CANCEL_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CANCEL_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CANCEL_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_ABORT_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_ABORT_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_ABOR_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_ABOR_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CONVEYER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CONVEYER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SHUTTER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SHUTTER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_FIRST_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_FIRST_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_SECOND_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_SECOND_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_THIRD_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_THIRD_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_FOURTH_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_FOURTH_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__ABNORMAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__ABNORMAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__EMPTY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__EMPTY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__IDLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__IDLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__RUN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__RUN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__PIN_UP
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__OR_PIN_UP")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__PIN_DOWN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__PIN_DOWN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__STOPPER_UP_OR_DOOR_OPEN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__STOPPER_UP_OR_DOOR_OPEN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__STOPPER_DOWN_OR_DOOR_CLOSE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__STOPPER_DOWN_OR_DOOR_CLOSE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MANUAL_OPERATION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MANUAL_OPERATION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__BODY_MOVING
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__BODY_MOVING")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__GLASS_EXIST_ARM1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__GLASS_EXIST_ARM1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__GLASS_EXIST_ARM2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__GLASS_EXIST_ARM2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__GLASS_EXIST_ARM3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__GLASS_EXIST_ARM3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__GLASS_EXIST_ARM4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__GLASS_EXIST_ARM4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE6
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE6")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE7
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE7")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_UP_CHK__MAKE_DEFINE8
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_UP_CHK__MAKE_DEFINE8")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_DOWNSTREAM_INLINE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_DOWNSTREAM_INLINE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_DOWNSTREAM_TROUBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_DOWNSTREAM_TROUBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SLOT_NUMBER1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SLOT_NUMBER1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SLOT_NUMBER2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SLOT_NUMBER2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SLOT_NUMBER3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SLOT_NUMBER3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SLOT_NUMBER4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SLOT_NUMBER4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_ARM_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_ARM_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_JOB_TRANSFER_SIGNAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_JOB_TRANSFER_SIGNAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_RECEIVE_ABLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_RECEIVE_ABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_RECEIVE_START
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_RECEIVE_START")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_RECEIVE_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_RECEIVE_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_EXCHANGE_POSSIBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_EXCHANGE_POSSIBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_EXCHANGE_EXECUTE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_EXCHANGE_EXECUTE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_RESUME_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_RESUME_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_RESUME_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_RESUME_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CANCEL_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CANCEL_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CANCEL_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CANCEL_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_ABORT_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_ABORT_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_ABORT_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_ABORT_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CONVEYER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CONVEYER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SHUTTER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SHUTTER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_FIRST_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_FIRST_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_SECOND_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_SECOND_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_THIRD_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_THIRD_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_FOURTH_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_FOURTH_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__ABNORMAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__ABNORMAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__EMPTY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__EMPTY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__IDLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__IDLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__RUN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__RUN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__LIFT_UP_OR_PIN_UP
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__LIFT_UP_OR_PIN_UP")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__LIFT_DOWN_OR_PIN_DOWN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__LIFT_DOWN_OR_PIN_DOWN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__STOPPER_UP_OR_DOOR_OPEN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__STOPPER_UP_OR_DOOR_OPEN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__STOPPER_DOWN_OR_DOOR_CLOSE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__STOPPER_DOWN_OR_DOOR_CLOSE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MANUAL_OPERATION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MANUAL_OPERATION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__BODY_MOVING
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__BODY_MOVING")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__GLASS_EXIST_ARM1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__GLASS_EXIST_ARM1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__GLASS_EXIST_ARM2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__GLASS_EXIST_ARM2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__GLASS_EXIST_ARM3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__GLASS_EXIST_ARM3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__GLASS_EXIST_ARM4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__GLASS_EXIST_ARM4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE6
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE6")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE7
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE7")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__OB_LINK_DOWN_CHK__MAKE_DEFINE8
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "OB_LINK_DOWN_CHK__MAKE_DEFINE8")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        #region YANGSYS

        private CControlAttribute @__VI_LOAD_REQUEST
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_LOAD_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_LOAD_ENABLE
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_LOAD_ENABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_LOAD_HAND_DOWN_COMPLETION_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_LOAD_HAND_DOWN_COMPLETION_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_LOAD_COMPLETE_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_LOAD_COMPLETE_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_UNLOAD_REQUEST
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_UNLOAD_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_UNLOAD_ENABLE
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_UNLOAD_ENABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_UNLOAD_HAND_UP_COMPLETION_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_UNLOAD_HAND_UP_COMPLETION_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_UNLOAD_COMPLETE_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_UNLOAD_COMPLETE_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_INITIALIZE_REQUEST
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_INITIALIZE_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_COMMUNICATION
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_COMMUNICATION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_ALIVE_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_ALIVE_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_STATE_REQUEST_ACK
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_STATE_REQUEST_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_STATE_CHANGE_REQ_ACK
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_STATE_CHANGE_REQ_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_STATE_CHANGE_EVENT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_STATE_CHANGE_EVENT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_STAGE_GLASS_EXIST
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_STAGE_GLASS_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_USER_LOGIN
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_USER_LOGIN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_USER_LOGIN_RECIPE
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_USER_LOGIN_RECIPE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }


        }
        private CControlAttribute @__VI_GLASS_DATA_SEND_ACK
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_GLASS_DATA_SEND_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_LOST_GLASS_DATA_REQUEST
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_LOST_GLASS_DATA_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_GLASS_SCRAP
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_GLASS_SCRAP")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_JOB_HOLD_EVENT_REPORT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_JOB_HOLD_EVENT_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_ALARM_SET
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_ALARM_SET")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_ALARM_RESET
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_ALARM_RESET")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_ALARM_SET_REQUEST_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_ALARM_SET_REQUEST_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_RECIPE_LIST_REQ_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_RECIPE_LIST_REQ_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_SHUTTER_STATUS_SEND
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_SHUTTER_STATUS_SEND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_RECIPE_REQUEST_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_RECIPE_REQUEST_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_CURRENT_RECIPE_CHANGE
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_CURRENT_RECIPE_CHANGE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_RECIPE_REPORT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_RECIPE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_RECIPE_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_RECIPE_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_MACHINE_MODE_CHANGE_REPORT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_MACHINE_MODE_CHANGE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_MACHINE_MODE_CHANGE_REQUEST_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_MACHINE_MODE_CHANGE_REQUEST_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_CVID_SEND
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_CVID_SEND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_CVID_REPORT_TIME_CHANGE_ACK
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_CVID_REPORT_TIME_CHANGE_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_PROCESS_STATUS_SEND
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_PROCESS_STATUS_SEND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_CIM_MODE_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_CIM_MODE_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_BUZZER_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_BUZZER_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_GLASS_DATA_VALUE_FILE_REPORT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_GLASS_DATA_VALUE_FILE_REPORT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_IONIZER
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_IONIZER")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_AUTO_MODE_CHANGE_EVENT
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_AUTO_MODE_CHANGE_EVENT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_OXR_INFORMATION_UPDATE
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_OXR_INFORMATION_UPDATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_OXR_INFORMATION_REQUEST_DATA_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_OXR_INFORMATION_REQUEST_DATA_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_TRACKING_DATA
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_TRACKING_DATA")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_TRANSFER_STOP_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_TRANSFER_STOP_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_CIM_MESSAGE_ON_REPLY
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_CIM_MESSAGE_ON_REPLY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_RECOVERY_GLASS_DATA_SEND_ACK
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_RECOVERY_GLASS_DATA_SEND_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        }

        private CControlAttribute @__VI_SVID_SEND
        {
            get
            {
                CControlAttribute attribute = null; foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "VI_SVID_SEND")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }

                    }

                }
                return attribute;
            }

        } 
        #endregion

        private CControlAttribute @__IB_TERMINAL_TEXT
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_TERMINAL_TEXT")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_OPERATOR_CALL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_OPERATOR_CALL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LD_BUZZ_ON
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LD_BUZZ_ON")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_DATE_TIME_SET
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_DATE_TIME_SET")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }

        }

        private CControlAttribute @__IB_PPID_RECIPE_ID_MAP_CHANGE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_PPID_RECIPE_ID_MAP_CHANGE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_EQUIPMENT_MODE_CHANGE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_EQUIPMENT_MODE_CHANGE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_PPID_RECIPE_MAP_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_PPID_RECIPE_MAP_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_RECIPE_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_RECIPE_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }
    }
}
