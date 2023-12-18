using System.ComponentModel;

namespace LexicalAnalysis.Types;

public enum KeywordsEnum
{
    [Description("and")]
    And,
    [Description("block_var_def")]
    BlockVarDef,
    [Description("case")]
    Case,
    [Description("class")]
    Class,
    [Description("end_prog")]
    EndProg,
    [Description("endblock_var_def")]
    EndBlockVarDef,
    [Description("false")]
    False,
    [Description("match")]
    Match,
    [Description("\n")]
    NewLine,
    [Description("not")]
    Not,
    [Description("or")]
    Or,
    [Description("start_prog")]
    StartProg,
    [Description("\t")]
    Tab,
    [Description("true")]
    True
}