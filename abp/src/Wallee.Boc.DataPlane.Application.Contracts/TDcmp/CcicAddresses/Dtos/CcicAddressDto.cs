using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

[Serializable]
public class CcicAddressDto : EntityDto
{
    /// <summary>
    /// �ͻ���
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// ��ַ����
    /// </summary>
    public string ADDR_TP { get; set; } = default!;

    /// <summary>
    /// ��ַ���
    /// </summary>
    public int ADDR_SN { get; set; }

    /// <summary>
    /// ���˱���
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    /// ��ַ����
    /// </summary>
    public string? ADDR_LANG { get; set; }

    /// <summary>
    /// ����/����
    /// </summary>
    public string? CNRG { get; set; }

    /// <summary>
    /// ʡ��/ֱϽ��
    /// </summary>
    public string? PRVC_MNCP { get; set; }

    /// <summary>
    /// ��
    /// </summary>
    public string? CITY { get; set; }

    /// <summary>
    /// ��/��
    /// </summary>
    public string? CNTY { get; set; }

    /// <summary>
    /// ��ַ(��ϸ��ַ)
    /// </summary>
    public string? ADDR1 { get; set; }

    /// <summary>
    /// �ʱ�
    /// </summary>
    public string? PSALC { get; set; }

    /// <summary>
    /// �˼���־
    /// </summary>
    public string? RTNPT_FLAG { get; set; }

    /// <summary>
    /// λ������
    /// </summary>
    public string? PS_NAME { get; set; }

    /// <summary>
    /// �������Դ���
    /// </summary>
    public string? CTY_LNG_CODE { get; set; }

    /// <summary>
    /// ���ҵ������յȼ�����
    /// </summary>
    public string? CTY_RGON_RSK_GRD_CODE { get; set; }

    /// <summary>
    /// �����������д���
    /// </summary>
    public string? RLTV_UNNPY_URBN_CODE { get; set; }

    /// <summary>
    /// ���п����д���
    /// </summary>
    public string? BKCD_URBN_CODE { get; set; }

    /// <summary>
    /// ��ϵ���ʹ���
    /// </summary>
    public string? REL_TP_CODE { get; set; }

    /// <summary>
    /// ��ϵ��ʼ����
    /// </summary>
    public DateTime? REL_STRT_DT { get; set; }

    /// <summary>
    /// ��ϵ��������
    /// </summary>
    public DateTime? REL_END_DT { get; set; }

    /// <summary>
    /// ��ϵ��ʼʱ��
    /// </summary>
    public TimeSpan? REL_STRT_TIME { get; set; }

    /// <summary>
    /// ��ϵ����ʱ��
    /// </summary>
    public TimeSpan? REL_END_TIME { get; set; }

    /// <summary>
    /// ��ϵ����
    /// </summary>
    public string? REL_DES { get; set; }

    /// <summary>
    /// ɾ����־
    /// </summary>
    public string? DEL_FLAG { get; set; }

    /// <summary>
    /// �����˹�Ա���
    /// </summary>
    public string? CRTR_TLR_REFNO { get; set; }

    /// <summary>
    /// ������Ա�������
    /// </summary>
    public string? CRT_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// ��������ʱ��
    /// </summary>
    public DateTime? CRT_DTTM { get; set; }

    /// <summary>
    /// ��ǰ�������
    /// </summary>
    public DateTime? CUR_ACDT_PERI { get; set; }

    /// <summary>
    /// �����޸Ĺ�Ա���
    /// </summary>
    public string? LTST_MOD_TLR_REFNO { get; set; }

    /// <summary>
    /// �޸Ĺ�Ա�������
    /// </summary>
    public string? MOD_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// ���ά��״̬����
    /// </summary>
    public string? LAST_MNT_STS_CODE { get; set; }

    /// <summary>
    /// ����޸�����ʱ��
    /// </summary>
    public DateTime? LAST_MOD_DTTM { get; set; }

    /// <summary>
    /// ��¼�汾���
    /// </summary>
    public decimal? RCRD_VRSN_SN { get; set; }

    /// <summary>
    /// ��¼����״̬����
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}