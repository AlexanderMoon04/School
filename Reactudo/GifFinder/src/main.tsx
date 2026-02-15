import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './constants/index.css'
import {GifsApp} from './components/GifsApp'

createRoot(document.getElementById('root') as HTMLElement).render(
  <StrictMode>
    <GifsApp />
  </StrictMode>
)