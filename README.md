# das-fat-jobs

[![Build Status](https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_apis/build/status/das-fat-jobs?repoName=SkillsFundingAgency%2Fdas-fat-jobs&branchName=main)](https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_build/latest?definitionId=2387&repoName=SkillsFundingAgency%2Fdas-fat-jobs&branchName=main)

# Requirements

DotNet Core 3.1 and any supported IDE for DEV running.

Azure Storage Emulator

## About

The fat jobs solution is responsible for running out of process data cleanup for the shortlists that are created in the Find Apprenticeship Training site. There is a timed job that is set to run at 4am every day. It gets the list of all expired shortlists - ones over 31 days in age, then calls to delete these orphaned records. They are orphaned as the cookie on the FAT site is only valid for 30 days

## Local running

You must have the Azure Storage emulator running, and in that a table created called `Configuration` in that table add the following:

PartitionKey: LOCAL

RowKey: SFA.DAS.FAT.Jobs_1.0

Data:
```
{
    "FatJobsApiConfiguration":
    {
        "BaseUrl":"https://localhost:5003/",
        "Key":"test"
    }
}

```

The function talks to the FAT outer api hosted with APIM - this is the only configuration item required.