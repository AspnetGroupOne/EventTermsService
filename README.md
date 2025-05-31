# EventTermsService

Made by https://github.com/SimonR-prog

# Postman:

## Authentication:

All requests to this API require an API-Key to be passed in the header under "X-API-KEY". 

Invalid requests will be met with:

```json
{
    "success": false,
    "error": "Invalid api-key or api-key is missing."
}
```

## POST and PUT: 

Is made by sending a request with no id at the end. 

www.EXAMPLEURL.net/api/Terms/

The api needs data that looks like this:

```json
{
    "eventId": "56f58514-7581-4b18-97f5-b6eb5ba7b9c9",
    "section": [
        {
            "id": 0,
            "termsId": 0,
            "header": "Ticket Purchase and Entry",
            "order": 0,
            "lines": [
                "refundable and non-transferable unless specified by the event organizer.",
                "Attendees must present a valid government-issued ID along with their ticket at the gate."
            ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Security and Safety",
                "order": 1,
                "lines": [
                    "Attendees are subject to security checks, including bag inspections, upon entry.",
                    "Prohibited items include weapons, drugs, alcohol, fireworks, and other hazardous materials."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Code of Conduct",
                "order": 2,
                "lines": [
                    "Attendees are expected to behave responsibly and respectfully toward others.",
                    "Any disruptive behavior, harassment, or illegal activity will result in immediate removal from the event without refund."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Event Schedule and Changes",
                "order": 3,
                "lines": [
                    "The event schedule is subject to change without prior notice.",
                    "The event organizer is not responsible for delays or cancellations caused by weather, technical issues, or unforeseen circumstances."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Photography and Recording",
                "order": 4,
                "lines": [
                    "Professional cameras and recording devices are prohibited unless authorized by the organizer."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Health and Safety",
                "order": 5,
                "lines": [
                    "Attendees must comply with health and safety guidelines, including those related to COVID-19 (if applicable).",
                    "The organizer reserves the right to enforce mask mandates or other health measures as necessary."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Liability",
                "order": 6,
                "lines": [
                    "The event organizer is not responsible for any personal injury, loss, or damage to personal property during the event."
                ],
            "termsEntity": null
        }
    ]
}

```


## GET:

Is made by sending a request with an id at the end. 

www.EXAMPLEURL.net/api/Terms/56f58514-7581-4b18-97f5-b6eb5ba7b9c9

And you will recieve data in json format that looks like this on success:

```json
{
    "content": {
        "eventId": "56f58514-7581-4b18-97f5-b6eb5ba7b9c9",
        "section": [
            {
                "id": 0,
                "termsId": 0,
                "header": "Ticket Purchase and Entry",
                "order": 0,
                "lines": [
                    "refundable and non-transferable unless specified by the event organizer.",
                    "Attendees must present a valid government-issued ID along with their ticket at the gate."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Security and Safety",
                "order": 1,
                "lines": [
                    "Attendees are subject to security checks, including bag inspections, upon entry.",
                    "Prohibited items include weapons, drugs, alcohol, fireworks, and other hazardous materials."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Code of Conduct",
                "order": 2,
                "lines": [
                    "Attendees are expected to behave responsibly and respectfully toward others.",
                    "Any disruptive behavior, harassment, or illegal activity will result in immediate removal from the event without refund."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Event Schedule and Changes",
                "order": 3,
                "lines": [
                    "The event schedule is subject to change without prior notice.",
                    "The event organizer is not responsible for delays or cancellations caused by weather, technical issues, or unforeseen circumstances."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Photography and Recording",
                "order": 4,
                "lines": [
                    "Professional cameras and recording devices are prohibited unless authorized by the organizer."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Health and Safety",
                "order": 5,
                "lines": [
                    "Attendees must comply with health and safety guidelines, including those related to COVID-19 (if applicable).",
                    "The organizer reserves the right to enforce mask mandates or other health measures as necessary."
                ],
                "termsEntity": null
            },
            {
                "id": 0,
                "termsId": 0,
                "header": "Liability",
                "order": 6,
                "lines": [
                    "The event organizer is not responsible for any personal injury, loss, or damage to personal property during the event."
                ],
                "termsEntity": null
            }
        ]
    },
    "success": true,
    "statusCode": 200,
    "message": null
}
```

## DELETE

Is made by sending a request with an id at the end. 

www.EXAMPLEURL.net/api/Terms/56f58514-7581-4b18-97f5-b6eb5ba7b9c9

Upon success you will recieve:

```json
{
    "success": true,
    "statusCode": 200,
    "message": null
}
```

# Sequence diagram plantuml

<img src="https://github.com/user-attachments/assets/b40b8e99-2622-4e10-98bb-4118f996583f" width="400">

# Usage in the frontend:

## Adding terms to the event:

<img src="https://github.com/user-attachments/assets/4a7fff7e-728a-418e-a8cf-d97767745b91" width="400">

## Showing the terms of an event:

<img src="https://github.com/user-attachments/assets/b708147a-f670-4c14-accb-428cc4a85d4b" width="400">

### Created By:

https://github.com/SimonR-prog
