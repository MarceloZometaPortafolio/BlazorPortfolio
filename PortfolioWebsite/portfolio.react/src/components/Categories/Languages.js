import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService'
import CategoryCard from './CategoryCard';

const Languages = () => {              
    const [languages, setLanguages] = useState([]);        

    const getLanguages = async() => {
        return await APIService.getLanguages();        
    }

    useEffect(() => {       
        getLanguages()
        .then(languagesFound => {
            setLanguages(languagesFound);
        })                        
    }, []);

    return(
        <div>
            <Card>
                <CardHeader title={"Languages"}/>
                <CardContent>                    
                    <CategoryCard category={languages}/>               
                </CardContent>
            </Card>
        </div>
    );
}

export default Languages