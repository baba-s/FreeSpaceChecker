# FreeSpaceChecker

指定したディスクの空き容量を Slack に通知するツール

## 使用例

### プロジェクトを実行する場合

```sh
dotnet run \
    --driveName "/" \
    --webhookUrl 【Webhook URL】 \
    --channel 【チャンネル名】 \
    --format "{0} GB"
```

### 実行ファイルを使用する場合

```sh
dotnet FreeSpaceChecker.dll \
    --driveName "/" \
    --webhookUrl 【Webhook URL】 \
    --channel 【チャンネル名】 \
    --format "{0} GB"
```
