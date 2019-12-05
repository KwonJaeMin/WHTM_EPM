using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Component;
using SOFD.Component.Interface;

namespace YANGSYS.ControlLib
{
    /// <summary>
    /// CIndexerControl의 요약
    /// </summary>
    public partial class CIndexerControl
    {
        private CControlAttribute @__IB_LINK_UP_UPSTREAM_INLINE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_UPSTREAM_INLINE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_UPSTREAM_TROUBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_UPSTREAM_TROUBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_NUMBER1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_NUMBER1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_NUMBER2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_NUMBER2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_NUMBER3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_NUMBER3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_NUMBER4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_NUMBER4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_NUMBER5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_NUMBER5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_ARM_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_ARM_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_JOB_TRANSFER_SIGNAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_JOB_TRANSFER_SIGNAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SEND_ABLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SEND_ABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SEND_START
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SEND_START")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SEND_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SEND_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_EXCHANGE_POSSIBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_EXCHANGE_POSSIBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_EXCHANGE_EXECUTE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_EXCHANGE_EXECUTE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_RESUME_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_RESUME_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_RESUME_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_RESUME_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CANCEL_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CANCEL_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CANCEL_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CANCEL_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_ABORT_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_ABORT_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_ABORT_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_ABORT_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CONVEYER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CONVEYER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SHUTTER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SHUTTER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_FIRST_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_FIRST_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_SECOND_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_SECOND_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_THIRD_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_THIRD_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_FOURTH_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_FOURTH_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_ABNORMAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_ABNORMAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_EMPTY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_EMPTY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_IDLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_IDLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_RUN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_RUN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_PIN_UP
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_OR_PIN_UP")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_PIN_DOWN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_PIN_DOWN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MANUAL_OPERATION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MANUAL_OPERATION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_BODY_MOVING
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_BODY_MOVING")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_GLASS_EXIST_ARM1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_GLASS_EXIST_ARM1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_GLASS_EXIST_ARM2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_GLASS_EXIST_ARM2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_GLASS_EXIST_ARM3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_GLASS_EXIST_ARM3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_GLASS_EXIST_ARM4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_GLASS_EXIST_ARM4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE6
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE6")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE7
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE7")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_UP_CHK_MAKE_DEFINE8
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_UP_CHK_MAKE_DEFINE8")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_DOWNSTREAM_INLINE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_DOWNSTREAM_INLINE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_DOWNSTREAM_TROUBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_DOWNSTREAM_TROUBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SLOT_NUMBER1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SLOT_NUMBER1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SLOT_NUMBER2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SLOT_NUMBER2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SLOT_NUMBER3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SLOT_NUMBER3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SLOT_NUMBER4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SLOT_NUMBER4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_JOB_TRANSFER_SIGNAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_JOB_TRANSFER_SIGNAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RECEIVE_ABLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RECEIVE_ABLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RECEIVE_START
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RECEIVE_START")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RECEIVE_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RECEIVE_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_EXCHANGE_POSSIBLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_EXCHANGE_POSSIBLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_EXCHANGE_EXECUTE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_EXCHANGE_EXECUTE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RESUME_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RESUME_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RESUME_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RESUME_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_CANCEL_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_CANCEL_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_CANCEL_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_CANCEL_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_ABORT_REQUEST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_ABORT_REQUEST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_ABORT_ACK
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_ABORT_ACK")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_CONVEYER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_CONVEYER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SHUTTER_STATE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SHUTTER_STATE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_FIRST_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_FIRST_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_SECOND_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_SECOND_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_THIRD_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_THIRD_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_FOURTH_SLOT_EXIST
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_FOURTH_SLOT_EXIST")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_ABNORMAL
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_ABNORMAL")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_EMPTY
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_EMPTY")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_IDLE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_IDLE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_RUN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_RUN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_COMPLETE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_COMPLETE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_LIFT_UP_OR_PIN_UP
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_LIFT_UP_OR_PIN_UP")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MANUAL_OPERATION
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MANUAL_OPERATION")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_BODY_MOVING
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_BODY_MOVING")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_GLASS_EXIST_ARM1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_GLASS_EXIST_ARM1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_GLASS_EXIST_ARM2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_GLASS_EXIST_ARM2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_GLASS_EXIST_ARM3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_GLASS_EXIST_ARM3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_GLASS_EXIST_ARM4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_GLASS_EXIST_ARM4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE1
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE1")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE2
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE2")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE3
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE3")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE4
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE4")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE5
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE5")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE6
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE6")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE7
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE7")
                        {
                            attribute = controlattribute as CControlAttribute; break;
                        }
                    }
                }
                return attribute;
            }
        }

        private CControlAttribute @__IB_LINK_DOWN_MAKE_DEFINE8
        {
            get
            {
                CControlAttribute attribute = null;
                foreach (IControlAttribute controlattribute in ControlAttributeCollecton.Values)
                {
                    if (ControlName == controlattribute.ControlName)
                    {
                        if (controlattribute.Attribute == "IB_LINK_DOWN_MAKE_DEFINE8")
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
