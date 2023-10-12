# Wallee.Boc.DataPlane


BUG:
升级到7.4.0之后出现了仓储方法FindAsync签名不一致的bug，这是我发的一个issue：https://github.com/abpframework/abp/issues/17850
现在暂时在项目中抑制了这个BUG，具体查询可以在项目中全局搜索：#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。