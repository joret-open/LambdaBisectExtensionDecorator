#/bin/bash
aws lambda get-event-source-mapping --uuid YOUR-EVENT-SOURCE-UUID --profile demo --region eu-west-1

aws logs tail /aws/lambda/lambda-decorator-demo --follow --profile demo --region eu-west-1 | grep ==
