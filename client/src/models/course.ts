export interface Course {
    id: string;
    title: string;
    price: number;
    instructor: string;
    image: string;
    rating: number;
    description: string;
    category: string;
    language: string;
    level: string;
    students: number;
    subTitle: string;
    learnings: Learning[] | [];
    requirements: Requirement[] | [];
    lastUpdated: Date;
}

export interface Learning {
    id: number;
    name: string;
}

export interface Requirement {
    id: number;
    name: string;
}
