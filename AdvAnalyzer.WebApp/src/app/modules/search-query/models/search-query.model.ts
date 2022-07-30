export interface SearchQuery {
    id: string;
    name: string;
    url: string;
    refreshFrequencyInMinutes: number;
    userId: number;
    sendEmailNotifications: boolean;
    dateAdded: Date;
    results: number;
    newResults: number;
}