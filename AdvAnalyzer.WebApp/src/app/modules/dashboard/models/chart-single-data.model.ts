export interface ChartData {
    chartData: ChartSingleData[];
}

export interface ChartSingleData {
    name: string;
    series: Serie[];
}

export interface Serie {
    name: string;
    value: number;
}