# FreeSpaceChecker

指定したディスクの空き容量を Slack に通知するツール

## 使用例

### シェルスクリプトでプロジェクトを実行する場合

```sh
dotnet run \
    --driveName "/" \
    --webhookUrl 【Webhook URL】 \
    --channel 【チャンネル名】 \
    --format "{0} GB"
```

### シェルスクリプトで実行ファイルを使用する場合

```sh
dotnet FreeSpaceChecker.dll \
    --driveName "/" \
    --webhookUrl 【Webhook URL】 \
    --channel 【チャンネル名】 \
    --format "{0} GB"
```

### Jenkinsfile で実行ファイルを使用する場合

```jenkinsfile
pipeline {
   agent any

   stages {
      stage( 'git clone' ) {
         steps {
            git branch: 'feature/v1.0.0', url: 'https://github.com/baba-s/FreeSpaceChecker.git'
         }
      }
      stage( 'dotnet' ) {
          steps {
            sh 'dotnet FreeSpaceChecker.dll --driveName "/" --webhookUrl 【Webhook URL】 --channel "" --format "{0} GB"'
          }
      }
   }
}
```
