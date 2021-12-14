using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : SoraLib.SingletonMono<RecordManager>
{
    public RecordHelper recordHelper;

    [Header(@"Uploading")]
    public string ComingTitle;
    public string ComingContent;
    public string FilePath;
}
