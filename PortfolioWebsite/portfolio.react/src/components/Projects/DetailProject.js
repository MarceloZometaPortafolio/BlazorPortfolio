import React, { useEffect, useState } from 'react'
import { Button, Card, CardContent, CardHeader, Container } from '@material-ui/core';
import ReactMarkdown from 'react-markdown'
import { getProjectBySlug } from '../../Data/APIService'
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    leftAligned: {
      textAlign : "left"
    },
  }));

const DetailProject = (props) => {
    const slug = props.match.params.slug;        
    const [project, setProject] = useState([]);
    const classes = useStyles();

    useEffect(() => {
        async function getProject(){
            let projectFound = await getProjectBySlug(slug);
            console.log(projectFound);
    
            setProject(projectFound);
        }
        
        getProject();
    }, [slug]);

    return(
        <div>
            <Card>
                <CardHeader title={project.title}/>
                <CardContent>
                    <CardHeader title="Requirements" className={classes.leftAligned}/>
                    <ReactMarkdown children={project.requirement} className={classes.leftAligned}/>

                    <CardHeader title="Design" className={classes.leftAligned}/>
                    <ReactMarkdown children={project.design} className={classes.leftAligned}/>

                    <CardHeader title="Completion Date" className={classes.leftAligned}/>
                    <ReactMarkdown children={project.CompletionDate} className={classes.leftAligned}/>                    
                </CardContent>
            </Card>
        </div>
    );
}

export default DetailProject