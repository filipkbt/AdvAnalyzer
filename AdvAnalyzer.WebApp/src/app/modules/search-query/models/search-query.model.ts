export interface SearchQuery {
    name: string;
    url: string;
    refreshFrequencyInMinutes: number;
    userId: number;
    sendEmailNotifications: boolean;
    dateAdded: Date;
    results: number;
    newResults: number;
}