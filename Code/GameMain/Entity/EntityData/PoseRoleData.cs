﻿using System;
using UnityEngine;
using GameFramework.DataTable;
namespace GameMain
{
    [Serializable]
    public class PoseRoleData : EntityData
    {
        [SerializeField]
        private ProfessionType m_ProfessionType;

        [SerializeField]
        private EffectData m_Effect01Data;

        [SerializeField]
        private EffectData m_Effect02Data;

        public PoseRoleData(int entityId, int typeId,ProfessionType professionType)
            : base(entityId, typeId)
        {
            m_ProfessionType = professionType;

            IDataTable<DRPoseRole> dtPoseRole = GameEntry.DataTable.GetDataTable<DRPoseRole>();
            DRPoseRole drPoseRole = dtPoseRole.GetDataRow(TypeId);
            if (drPoseRole == null)
            {
                return;
            }

            m_ProfessionType = drPoseRole.ProfessionType;
            m_Effect01Data = new EffectData(GameEntry.Entity.GenerateTempSerialId(),drPoseRole.Effect01,drPoseRole.Effect01Duration,drPoseRole.Effect01Delay);
            m_Effect02Data = new EffectData(GameEntry.Entity.GenerateTempSerialId(), drPoseRole.Effect02, drPoseRole.Effect02Duration, drPoseRole.Effect02Delay);
        }

        /// <summary>
        /// 职业类型
        /// </summary>
        public ProfessionType PrefessionTyoe
        {
            get 
            {
                return m_ProfessionType;
            }
        }

        /// <summary>
        /// 特效01数据
        /// </summary>
        public EffectData Effect01Data
        {
            get 
            {
                return m_Effect01Data;
            }
        }

        /// <summary>
        /// 特效02数据
        /// </summary>
        public EffectData Effect02Data
        {
            get 
            {
                return m_Effect02Data;
            }
        }

    }
}