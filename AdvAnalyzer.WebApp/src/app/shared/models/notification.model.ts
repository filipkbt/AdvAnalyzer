export interface Notification {
    id: number;
    message: string;
    dateAdded: Date;
    isSeen: boolean;
    searchQueryId: string;
}