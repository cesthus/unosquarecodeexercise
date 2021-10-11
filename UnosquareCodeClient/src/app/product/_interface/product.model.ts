export interface Product{
    id: number;
    name: string;
    description: string;
    ageRestriccion: number;
    company: string;
    price: number;
}

export interface ProductForCreation {
    name: string;
    description: string;
    ageRestriccion: number;
    company: string;
    price: number;
}

export interface ProductForUpdate{
    id: number;
    Name: string;
    description: string;
    ageRestriccion: number;
    Company: string;
    price: number;
}