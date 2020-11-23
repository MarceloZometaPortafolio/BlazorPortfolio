import * as React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Toolbar from '@material-ui/core/Toolbar';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import MenuIcon from '@material-ui/icons/Menu';
import { AuthConsumer } from "./authContext";
import AuthenticateButton from './Authentication/AuthenticateButton';

const useStyles = makeStyles((theme) => ({
  toolbar: {
    borderBottom: `1px solid ${theme.palette.divider}`,
    backgroundColor: '#ffffff'
  },
  toolbarTitle: {
    flex: 1,
  },
  toolbarSecondary: {
    justifyContent: 'space-between',
    overflowX: 'auto',
  },
  toolbarLink: {
    padding: theme.spacing(1),
    flexShrink: 0,
  },
}));

interface HeaderProps {
  sections: Array<{
    title: string;
    url: string;
  }>;
  title: string;
}

export default function Header(props: HeaderProps) {
  const classes = useStyles();
  const { sections, title } = props;
  const [isVisible, setVisibleMenu] = React.useState(false);

  return (
    // <React.Fragment>    
      <div className="myHeader">
        <Toolbar className={classes.toolbar}>
          <div onClick={() => setVisibleMenu(!isVisible)}>
            <MenuIcon/>
          </div>
          <Typography
            component="h2"
            variant="h5"
            color="inherit"
            align="center"
            noWrap
            className={classes.toolbarTitle}
          >
            <Link color="inherit" href="/">
              {title}
            </Link>
          </Typography>
          <AuthenticateButton/>
        </Toolbar>
        <Toolbar
          component="nav"
          variant="dense"
          className={classes.toolbarSecondary}
        >        
          {isVisible && sections.map((section) => (
            <Link
              color="inherit"
              noWrap
              key={section.title}
              variant="body2"
              href={section.url}
              className={classes.toolbarLink}            
            >
              {section.title}
            </Link>
          ))}
        </Toolbar>
      </div>    
  );
}
